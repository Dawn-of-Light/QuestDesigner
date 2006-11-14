--- ATTENTION ---

Using DOL Database in Quest Designer

To enabled the DOL Database connectivity of the Quest Designer you have to update the included DOL Server configuration in /config/dol/serverconfig.xml.
The simpliest way would be to copy the one from your DOL-Server over this one since the DB Connection settings will probably be the same. If you do so and use a XML-Database make sure the ConnectionString contains a absolute path. For MYSQL everything should be fine if you only copy it.

If you have problems with it come to www.dolserver.net and ask in the Developer Forum->3rd Party Tools.