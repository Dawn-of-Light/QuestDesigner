using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;

namespace QuestDesigner.Controls
{
	public class RichTextBoxEx : RichTextBox
	{
		

		#region Interop-Defines
		[ StructLayout( LayoutKind.Sequential )]
		private struct CHARFORMAT2_STRUCT
		{
			public UInt32	cbSize; 
			public UInt32   dwMask; 
			public UInt32   dwEffects; 
			public Int32    yHeight; 
			public Int32    yOffset; 
			public Int32	crTextColor; 
			public byte     bCharSet; 
			public byte     bPitchAndFamily; 
			[MarshalAs(UnmanagedType.ByValArray, SizeConst=32)]
			public char[]   szFaceName; 
			public UInt16	wWeight;
			public UInt16	sSpacing;
			public int		crBackColor; // Color.ToArgb() -> int
			public int		lcid;
			public int		dwReserved;
			public Int16	sStyle;
			public Int16	wKerning;
			public byte		bUnderlineType;
			public byte		bAnimation;
			public byte		bRevAuthor;
			public byte		bReserved1;
		}

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);		

		private const int WM_USER			 = 0x0400;
		private const int EM_GETCHARFORMAT	 = WM_USER+58;
		private const int EM_SETCHARFORMAT	 = WM_USER+68;

		private const int SCF_SELECTION	= 0x0001;
		private const int SCF_WORD		= 0x0002;
		private const int SCF_ALL		= 0x0004;		
		

		#region CHARFORMAT2 Flags
		private const UInt32 CFE_BOLD		= 0x0001;
		private const UInt32 CFE_ITALIC		= 0x0002;
		private const UInt32 CFE_UNDERLINE	= 0x0004;
		private const UInt32 CFE_STRIKEOUT	= 0x0008;
		private const UInt32 CFE_PROTECTED	= 0x0010;
		private const UInt32 CFE_LINK		= 0x0020;
		private const UInt32 CFE_AUTOCOLOR	= 0x40000000;
		private const UInt32 CFE_SUBSCRIPT	= 0x00010000;		/* Superscript and subscript are */
		private const UInt32 CFE_SUPERSCRIPT= 0x00020000;		/*  mutually exclusive			 */

		private const int CFM_SMALLCAPS		= 0x0040;			/* (*)	*/
		private const int CFM_ALLCAPS		= 0x0080;			/* Displayed by 3.0	*/
		private const int CFM_HIDDEN		= 0x0100;			/* Hidden by 3.0 */
		private const int CFM_OUTLINE		= 0x0200;			/* (*)	*/
		private const int CFM_SHADOW		= 0x0400;			/* (*)	*/
		private const int CFM_EMBOSS		= 0x0800;			/* (*)	*/
		private const int CFM_IMPRINT		= 0x1000;			/* (*)	*/
		private const int CFM_DISABLED		= 0x2000;
		private const int CFM_REVISED		= 0x4000;

		private const int CFM_BACKCOLOR		= 0x04000000;
		private const int CFM_LCID			= 0x02000000;
		private const int CFM_UNDERLINETYPE	= 0x00800000;		/* Many displayed by 3.0 */
		private const int CFM_WEIGHT		= 0x00400000;
		private const int CFM_SPACING		= 0x00200000;		/* Displayed by 3.0	*/
		private const int CFM_KERNING		= 0x00100000;		/* (*)	*/
		private const int CFM_STYLE			= 0x00080000;		/* (*)	*/
		private const int CFM_ANIMATION		= 0x00040000;		/* (*)	*/
		private const int CFM_REVAUTHOR		= 0x00008000;


		private const UInt32 CFM_BOLD		= 0x00000001;
		private const UInt32 CFM_ITALIC		= 0x00000002;
		private const UInt32 CFM_UNDERLINE	= 0x00000004;
		private const UInt32 CFM_STRIKEOUT	= 0x00000008;
		private const UInt32 CFM_PROTECTED	= 0x00000010;
		private const UInt32 CFM_LINK		= 0x00000020;
		private const UInt32 CFM_SIZE		= 0x80000000;
		private const UInt32 CFM_COLOR		= 0x40000000;
		private const UInt32 CFM_FACE		= 0x20000000;
		private const UInt32 CFM_OFFSET		= 0x10000000;
		private const UInt32 CFM_CHARSET	= 0x08000000;
		private const UInt32 CFM_SUBSCRIPT	= CFE_SUBSCRIPT | CFE_SUPERSCRIPT;
		private const UInt32 CFM_SUPERSCRIPT= CFM_SUBSCRIPT;

		private const byte CFU_UNDERLINENONE		= 0x00000000;
		private const byte CFU_UNDERLINE			= 0x00000001;
		private const byte CFU_UNDERLINEWORD		= 0x00000002; /* (*) displayed as ordinary underline	*/
		private const byte CFU_UNDERLINEDOUBLE		= 0x00000003; /* (*) displayed as ordinary underline	*/
		private const byte CFU_UNDERLINEDOTTED		= 0x00000004;
		private const byte CFU_UNDERLINEDASH		= 0x00000005;
		private const byte CFU_UNDERLINEDASHDOT		= 0x00000006;
		private const byte CFU_UNDERLINEDASHDOTDOT	= 0x00000007;
		private const byte CFU_UNDERLINEWAVE		= 0x00000008;
		private const byte CFU_UNDERLINETHICK		= 0x00000009;
		private const byte CFU_UNDERLINEHAIRLINE	= 0x0000000A; /* (*) displayed as ordinary underline	*/

		#endregion

		#endregion

		public RichTextBoxEx()
		{
			// Otherwise, non-standard links get lost when user starts typing
			// next to a non-standard link
			this.DetectUrls = false;

			//this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		#region Begin/EndUpdate

		//used for saving and restoring the scroll position to avoid flickering... 
		[StructLayout(LayoutKind.Sequential)] 
		private struct POINT 
		{ 
			public long X; 
			public long Y; 
		}

		//used to store the scroll position at the start of updating 
		POINT _scrollpos = new POINT(); 				

		private int updating = 0;
		private int oldEventMask = 0;

		// Constants from the Platform SDK.
		private const int EM_SETEVENTMASK = 1073;
		private const int WM_SETREDRAW = 11;

		private const int EM_GETSCROLLPOS = 0x0400 + 221; 
		private const int EM_SETSCROLLPOS = 0x0400 + 222;

		[DllImport("user32", CharSet = CharSet.Auto)]
		private static extern int SendMessage(HandleRef hWnd,
											   int msg,
											   int wParam,
											   int lParam);		

		[DllImport( "user32", CharSet = CharSet.Auto )] 
		private static extern int SendMessage( HandleRef hWnd, int msg, int wParam, ref POINT lp ); 		

		public void BeginUpdate()
		{
			// Deal with nested calls.
			++updating;

			if (updating > 1)
				return;

			SendMessage(new HandleRef(this, Handle), EM_GETSCROLLPOS, 0, ref _scrollpos); 

			// Prevent the control from raising any events.
			oldEventMask = SendMessage(new HandleRef(this, Handle),	EM_SETEVENTMASK, 0, 0);

			// Prevent the control from redrawing itself.
			SendMessage(new HandleRef(this, Handle), WM_SETREDRAW, 0, 0);
		}

		/// <SUMMARY>
		/// Resumes drawing and event handling.
		/// </SUMMARY>
		/// <REMARKS>
		/// This method should be called every time a call is made
		/// made to BeginUpdate. It resets the event mask to it's
		/// original value and enables redrawing of the control.
		/// </REMARKS>
		public void EndUpdate()
		{
			// Deal with nested calls.
			--updating;

			if (updating > 0)
				return;

			SendMessage(new HandleRef(this, Handle), EM_SETSCROLLPOS, 0, ref _scrollpos);

			// Allow the control to redraw itself.
			SendMessage(new HandleRef(this, Handle), WM_SETREDRAW, 1, 0);

			// Allow the control to raise event messages.
			SendMessage(new HandleRef(this, Handle), EM_SETEVENTMASK, 0, oldEventMask);

			Refresh();			
		}

		/// <SUMMARY>
		/// Returns true when the control is performing some 
		/// internal updates, specially when is reading or writing
		/// HTML text
		/// </SUMMARY>
		public bool InternalUpdating
		{
			get
			{
				return (updating != 0);
			}
		}

		#endregion

		[DefaultValue(false)]
		public new bool DetectUrls
		{
			get { return base.DetectUrls; }
			set { base.DetectUrls = value; }
		}

		public int SelectionEnd
		{
			get { return SelectionStart + SelectionLength; }
			set { SelectionLength = value - SelectionStart; }
		}

		public void AppendLink(string text)
		{
			InsertLink(text, TextLength);
		}

		public void AppendLink(string text, string hyperlink)
		{
			InsertLink(text, hyperlink, TextLength);
		}

		// Colors the text between begin and end index in a specific color
		public void Color(int begin, int end, Color color)
		{
			int origStart = SelectionStart;
			int origLength = SelectionLength;

			SelectRange(begin, end);
			SelectionColor = color;

			SelectionStart = origStart;
			SelectionLength = origLength;
		}

		public void SelectRange(int begin, int end)
		{
			Select(begin, end - begin);
		}

		/// <summary>
		/// Insert a given text into the RichTextBox at the current insert position.
		/// </summary>
		/// <param name="text">Text to be inserted</param>
		public void InsertText(string text)
		{
			InsertText(text, this.SelectionStart);
		}

		/// <summary>
		/// Insert a given text at a given position. 
		/// </summary>
		/// <param name="text">Text to be inserted</param>
		/// <param name="position">Insert position</param>
		public void InsertText(string text, int position)
		{
			if (position < 0 || position > this.Text.Length)
				throw new ArgumentOutOfRangeException("position");

			this.Select(position,0);
			this.SelectedText = text;
			this.Select(position + text.Length, 0);
		}

		/// <summary>
		/// Insert a given text as a link into the RichTextBox at the current insert position.
		/// </summary>
		/// <param name="text">Text to be inserted</param>
		public void InsertLink(string text)
		{
			InsertLink(text, this.SelectionStart);
		}

		/// <summary>
		/// Insert a given text at a given position as a link. 
		/// </summary>
		/// <param name="text">Text to be inserted</param>
		/// <param name="position">Insert position</param>
		public void InsertLink(string text, int position)
		{
			if (position < 0 || position > this.Text.Length)
				throw new ArgumentOutOfRangeException("position");

			this.SelectionStart = position;
			this.SelectionLength = 0;
			this.SelectedText = text;
			this.Select(position, text.Length);
			this.SetSelectionLink(true);
			this.Select(position + text.Length, 0);
		}
		
		/// <summary>
		/// Insert a given text at at the current input position as a link.
		/// The link text is followed by a hash (#) and the given hyperlink text, both of
		/// them invisible.
		/// When clicked on, the whole link text and hyperlink string are given in the
		/// LinkClickedEventArgs.
		/// </summary>
		/// <param name="text">Text to be inserted</param>
		/// <param name="hyperlink">Invisible hyperlink string to be inserted</param>
		public void InsertLink(string text, string hyperlink)
		{
			InsertLink(text, hyperlink, this.SelectionStart);
		}

		/// <summary>
		/// Insert a given text at a given position as a link. The link text is followed by
		/// a hash (#) and the given hyperlink text, both of them invisible.
		/// When clicked on, the whole link text and hyperlink string are given in the
		/// LinkClickedEventArgs.
		/// </summary>
		/// <param name="text">Text to be inserted</param>
		/// <param name="hyperlink">Invisible hyperlink string to be inserted</param>
		/// <param name="position">Insert position</param>
		public void InsertLink(string text, string hyperlink, int position)
		{
			if (position < 0 || position > this.Text.Length)
				throw new ArgumentOutOfRangeException("position");

			this.SelectionStart = position;
			this.SelectionLength = 0;
			this.SelectedRtf = @"{\rtf1\ansi "+text+@"\v #"+hyperlink+@"\v0}";
			this.Select(position, text.Length + hyperlink.Length + 1);
			this.SetSelectionLink(true);
			this.Select(position + text.Length + hyperlink.Length + 1, 0);
		}

		/// <summary>
		/// Set the current selection's link style
		/// </summary>
		/// <param name="link">true: set link style, false: clear link style</param>
		public void SetSelectionLink(bool link)
		{
			SetSelectionStyle(CFM_LINK, link ? CFE_LINK : 0);
		}
		/// <summary>
		/// Get the link style for the current selection
		/// </summary>
		/// <returns>0: link style not set, 1: link style set, -1: mixed</returns>
		public int GetSelectionLink()
		{
			return GetSelectionStyle(CFM_LINK, CFE_LINK);
		}


		private void SetSelectionStyle(UInt32 mask, UInt32 effect)
		{
			CHARFORMAT2_STRUCT cf = new CHARFORMAT2_STRUCT();
			cf.cbSize = (UInt32)Marshal.SizeOf(cf);
			cf.dwMask = mask;
			cf.dwEffects = effect;

			IntPtr wpar = new IntPtr(SCF_SELECTION);
			IntPtr lpar = Marshal.AllocCoTaskMem( Marshal.SizeOf( cf ) ); 
			Marshal.StructureToPtr(cf, lpar, false);

			IntPtr res = SendMessage(Handle, EM_SETCHARFORMAT, wpar, lpar);

			Marshal.FreeCoTaskMem(lpar);
		}

		private int GetSelectionStyle(UInt32 mask, UInt32 effect)
		{
			CHARFORMAT2_STRUCT cf = new CHARFORMAT2_STRUCT();
			cf.cbSize = (UInt32)Marshal.SizeOf(cf);
			cf.szFaceName = new char[32];

			IntPtr wpar = new IntPtr(SCF_SELECTION);
			IntPtr lpar = 	Marshal.AllocCoTaskMem( Marshal.SizeOf( cf ) ); 
			Marshal.StructureToPtr(cf, lpar, false);

			IntPtr res = SendMessage(Handle, EM_GETCHARFORMAT, wpar, lpar);

			cf = (CHARFORMAT2_STRUCT)Marshal.PtrToStructure(lpar, typeof(CHARFORMAT2_STRUCT));

			int state;
			// dwMask holds the information which properties are consistent throughout the selection:
			if ((cf.dwMask & mask) == mask) 
			{
				if ((cf.dwEffects & effect) == effect)
					state = 1;
				else
					state = 0;
			}
			else
			{
				state = -1;
			}
			
			Marshal.FreeCoTaskMem(lpar);
			return state;
		}
	}
}
