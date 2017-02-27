DROP TABLE [TB_COLUMN_FILTER_MANAGER];

CREATE TABLE "TB_COLUMN_FILTER_MANAGER"(
[CFM_FILTER_SRNO] integer PRIMARY KEY UNIQUE NOT NULL
,[CFM_VIEW_SRNO] integer NOT NULL
,[CFM_COLUMN_INDEX] integer NOT NULL
,[CFM_FILTER_TYPE] text NOT NULL
,[CFM_FILTER_DATA_INDEX] text NOT NULL
,[CFM_FILTER_DISABLED] integer
,[CFM_FILTER_CODE_DESC] text
,[CFM_FILTER_CODE_QUERY] text
,[CFM_CREATE_USER_SRNO] integer NOT NULL
,[CFM_CREATE_DATE_TIME] datetime NOT NULL
,[CFM_UPDATE_USER_SRNO] integer
,[CFM_UPDATE_DATE_TIME] datetime
  
);