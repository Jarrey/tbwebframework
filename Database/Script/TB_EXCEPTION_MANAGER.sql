
DROP TABLE [TB_EXCEPTION_MANAGER];

CREATE TABLE "TB_EXCEPTION_MANAGER"(
[EM_EXCEPTION_SRNO] integer PRIMARY KEY UNIQUE NOT NULL
,[EM_DATE_TIME] datetime NOT NULL
,[EM_TITLE] text NOT NULL
,[EM_CONTEXT] text NOT NULL
,[EM_STATUS] integer NOT NULL
,[EM_UPDATE_USER_SRNO] integer
,[EM_UPDATE_TIME] datetime
  
);