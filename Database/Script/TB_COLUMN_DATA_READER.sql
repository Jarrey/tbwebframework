DROP TABLE [TB_COLUMN_DATA_READER];

CREATE TABLE "TB_COLUMN_DATA_READER"(
[CDR_COLUMN_SRNO] integer PRIMARY KEY UNIQUE NOT NULL
,[CDR_VIEW_SRNO] integer NOT NULL
,[CDR_DATA_INDEX_NAME] text NOT NULL
,[CDR_MAPPING] text
,[CDR_CREATE_USER_SRNO] integer NOT NULL
,[CDR_CREATE_DATE_TIME] datetime NOT NULL
,[CDR_UPDATE_USER_SRNO] integer
,[CDR_UPDATE_DATE_TIME] datetime
  
);