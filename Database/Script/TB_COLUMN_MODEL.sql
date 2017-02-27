DROP TABLE "TB_COLUMN_MODEL";

CREATE TABLE "TB_COLUMN_MODEL"(
[CM_COLUMN_SRNO] integer PRIMARY KEY UNIQUE NOT NULL
,[CM_VIEW_SRNO] integer NOT NULL
,[CM_COLUMN_NAME] text NOT NULL
,[CM_COLUMN_LANG_SRNO] text
,[CM_COLUMN_INDEX] integer NOT NULL
,[CM_COLUMN_CATEGORY] integer NOT NULL
,[CM_COLUMN_DATA_INDEX] text NOT NULL
,[CM_COLUMN_TYPE] text
,[CM_COLUMN_WIDTH] float
,[CM_COLUMN_ALIGN] integer
,[CM_COLUMN_TOOLTIP] text
,[CM_COLUMN_CSS] text
,[CM_COLUMN_TPL] text
,[CM_COLUMN_SORTABLE] integer
,[CM_COLUMN_RESIZABLE] integer
,[CM_COLUMN_EDITABLE] integer
,[CM_COLUMN_EDITOR] text
,[CM_COLUMN_RENDERER] text
,[CM_COLUMN_SCOPE] text
,[CM_CREATE_USER_SRNO] integer NOT NULL
,[CM_CREATE_DATE_TIME] datetime NOT NULL
,[CM_UPDATE_USER_SRNO] integer
,[CM_UPDATE_DATE_TIME] datetime
  
);