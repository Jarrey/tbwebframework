Imports Manage
Imports Utils
Imports System.Web
Imports ResponseMessageStructs

''' <summary>
''' 请求处理服务基类
''' </summary>
''' <remarks></remarks>
Public Class clsBaseServer

  ''' <summary>
  ''' 请求标识枚举
  ''' </summary>
  ''' <remarks></remarks>
  Public Enum EnmRequestIndc
    ''' <summary>
    ''' 保存文本内容
    ''' </summary>
    ''' <remarks></remarks>
    RQ_SAVE = 100
    ''' <summary>
    ''' 导出网格
    ''' </summary>
    ''' <remarks></remarks>
    RQ_EXPORT_GRID = 101
    ''' <summary>
    ''' 打印
    ''' </summary>
    ''' <remarks></remarks>
    RQ_PRINT = 102
    ''' <summary>
    ''' 查询请求
    ''' </summary>
    ''' <remarks></remarks>
    RQ_SEARCH = 1000
    ''' <summary>
    ''' 更新请求
    ''' </summary>
    ''' <remarks></remarks>
    RQ_UPDATE = 1001
    ''' <summary>
    ''' 删除请求
    ''' </summary>
    ''' <remarks></remarks>
    RQ_DELETE = 1002
    ''' <summary>
    ''' 删除全部请求
    ''' </summary>
    ''' <remarks></remarks>
    RQ_DELETEALL = 1003
    ''' <summary>
    ''' 初始化菜单
    ''' </summary>
    ''' <remarks></remarks>
    RQ_INIT_MENU = 1004
    ''' <summary>
    ''' 初始化GridView
    ''' </summary>
    ''' <remarks></remarks>
    RQ_INIT_GRIDVIEW = 1005
    ''' <summary>
    ''' 初始化列表类控件
    ''' </summary>
    ''' <remarks></remarks>
    RQ_INIT_LST_CONTROLS = 1006
    ''' <summary>
    ''' 初始化 List View 列
    ''' </summary>
    ''' <remarks></remarks>
    RQ_INIT_LST_VIEW = 1007
    ''' <summary>
    ''' 查询全部请求
    ''' </summary>
    ''' <remarks></remarks>
    RQ_SEARCHALL = 1008
  End Enum

  Protected Delegate Sub mDlgProcessFunction(ByVal aObjRequest As HttpRequest, ByRef aObjResponse As HttpResponse)
  Private mHstResponseProcess As Hashtable
  Private mObjColumnDefinationManager As New clsColumnDefinationManager
  Private mObjCodeMasterManager As New clsCodeMasterManager

  '回复消息体
  Protected mObjResponseMessage As ResponseMessageStructs.clsResponseMessageStruct

  Sub New()
    mHstResponseProcess = New Hashtable
    mHstResponseProcess.Clear()
  End Sub

  ''' <summary>
  ''' 注册方法
  ''' </summary>
  ''' <param name="aIntResponseIndc">请求类型</param>
  ''' <param name="aObjProcessFunction">处理函数</param>
  ''' <remarks></remarks>
  Protected Sub ResponseServerRegister(ByVal aIntResponseIndc As Integer, ByVal aObjProcessFunction As mDlgProcessFunction)
    If mHstResponseProcess.ContainsKey(aIntResponseIndc) Then
      mHstResponseProcess(aIntResponseIndc) = aObjProcessFunction
    Else
      mHstResponseProcess.Add(aIntResponseIndc, aObjProcessFunction)
    End If
  End Sub

  ''' <summary>
  ''' 处理请求
  ''' </summary>
  ''' <param name="aObjRequest"></param>
  ''' <param name="aObjResponse"></param>
  ''' <remarks></remarks>
  Public Sub mProcessRequest(ByVal aObjRequest As HttpRequest, ByRef aObjResponse As HttpResponse)
    Dim lIntRequestIndc As Integer

    '输出调试信息
    clsLogManager.mPrLogAppInfo( _
      clsLogMessagrStruct.EnmLogCategory.DEBUG_INFO, _
      " Request Page : " & aObjRequest.ApplicationPath & _
      "; Request Path : " & aObjRequest.Path & _
      "; Request Browser : " & aObjRequest.Browser.Browser & _
      "; Request ContentType : " & aObjRequest.ContentType & _
      "; Request Url : " & aObjRequest.Url.ToString & _
      "; Request UserAgent : " & aObjRequest.UserAgent & _
      "; Request UserHostAddress : " & aObjRequest.UserHostAddress & _
      "; Request UserHostName : " & aObjRequest.UserHostName, _
      clsLogMessagrStruct.EnmLogLevel.DEBUG)

    If IsNumeric(aObjRequest("prRequestIndc")) Then lIntRequestIndc = CInt(aObjRequest("prRequestIndc"))
    mObjResponseMessage = New clsResponseMessageStruct
    mObjResponseMessage.mPrpRequestIndc = lIntRequestIndc
    If mHstResponseProcess.ContainsKey(lIntRequestIndc) Then
      CType(mHstResponseProcess(lIntRequestIndc), mDlgProcessFunction).Invoke(aObjRequest, aObjResponse)
    Else
      mObjResponseMessage.mPrpMessageStatusIndc = clsResponseMessageStruct.EnmMessageStatusIndc.FAIL
      mObjResponseMessage.mPrpMessage = clsMessageDictionaryManager.mFnGetMessageDesc(1001, mIntGlobal_Language_Indc)
      aObjResponse.Write(mObjResponseMessage.ToJsonString)

      clsLogManager.mPrLogAppInfo(clsLogMessagrStruct.EnmLogCategory.DEBUG_INFO, " Response Context : " & mObjResponseMessage.ToJsonString, clsLogMessagrStruct.EnmLogLevel.DEBUG)
    End If
    aObjResponse.ContentType = clsParameterManager.mFnGetParameters(GP_RESPONSE_CONENT_TYPE)

    '输出调试信息
    clsSystemMessageManager.mPrPushSystemMessage(clsSystemMessageStruct.EnmMessageType.DEBUG_INFO, " Response Status : " & aObjResponse.Status, , clsSystemMessageStruct.EnmMessageLevel.DEBUG)
    clsLogManager.mPrLogAppInfo(clsLogMessagrStruct.EnmLogCategory.DEBUG_INFO, " Response Status : " & aObjResponse.Status, clsLogMessagrStruct.EnmLogLevel.DEBUG)
  End Sub

  ''' <summary>
  ''' 处理初始化GridView请求,返回GridView结构数据
  ''' 返回数据类型 Json 类型
  ''' </summary>
  ''' <param name="aObjRequest"></param>
  ''' <param name="aObjResponse"></param>
  ''' <remarks></remarks>
  Protected Sub mPrProcessInitGridView(ByVal aObjRequest As HttpRequest, ByRef aObjResponse As HttpResponse)

    '声明
    Dim lObjGridModelList As New List(Of clsGridColumnModelJsonStruct)
    Dim lObjColumnDataReaderlList As New List(Of clsColumnDataReaderJsonStruct)
    Dim lObjColumnFilterList As New List(Of clsColumnFilterJsonStruct)
    Dim lIntGridViewCategory As Integer = 0
    Dim lLngGridViewSrno As Long = 0

    Try
      '获得请求数据
      If IsNumeric(aObjRequest("prGridViewCategory")) Then lIntGridViewCategory = CInt(aObjRequest("prGridViewCategory"))
      If IsNumeric(aObjRequest("prGirdViewSrno")) Then lLngGridViewSrno = CLng(aObjRequest("prGirdViewSrno"))

      '生成回复值
      lObjGridModelList = mObjColumnDefinationManager.mInitColumnModelStruct(Of clsGridColumnModelJsonStruct)(lLngGridViewSrno, lIntGridViewCategory)
      lObjColumnDataReaderlList = mObjColumnDefinationManager.mInitColumnDataReaderStuct(lLngGridViewSrno)
      lObjColumnFilterList = mObjColumnDefinationManager.mInitColumnFilterStruct(lLngGridViewSrno)
      If lObjGridModelList.Count = 0 Or lObjColumnDataReaderlList.Count = 0 Then
        mObjResponseMessage.mPrpMessage = clsMessageDictionaryManager.mFnGetMessageDesc(1007, mIntGlobal_Language_Indc)
      Else
        mObjResponseMessage.mPrpMessageStatusIndc = clsResponseMessageStruct.EnmMessageStatusIndc.SUCCESS
        mObjResponseMessage.mPrpMessageBody = clsGridColumnModelJsonStruct.ToJSONArray(lObjGridModelList) & "," & _
                                              clsColumnDataReaderJsonStruct.ToJSONArray(lObjColumnDataReaderlList) & "," & _
                                              clsColumnFilterJsonStruct.ToJSONArray(lObjColumnFilterList)
      End If
      aObjResponse.Write(mObjResponseMessage.ToJsonString)

      clsSystemMessageManager.mPrPushSystemMessage(clsSystemMessageStruct.EnmMessageType.DEBUG_INFO, " Response Context : " & mObjResponseMessage.ToJsonString, , clsSystemMessageStruct.EnmMessageLevel.DEBUG)
      clsLogManager.mPrLogAppInfo(clsLogMessagrStruct.EnmLogCategory.DEBUG_INFO, " Response Context : " & mObjResponseMessage.ToJsonString, clsLogMessagrStruct.EnmLogLevel.DEBUG)
    Catch ex As Exception
      Throw ex
    End Try
  End Sub

  ''' <summary>
  ''' 处理初始化ListView请求,返回ListView列数据
  ''' 返回数据类型 Json 类型
  ''' </summary>
  ''' <param name="aObjRequest"></param>
  ''' <param name="aObjResponse"></param>
  ''' <remarks></remarks>
  Protected Sub mPrProcessInitListView(ByVal aObjRequest As HttpRequest, ByRef aObjResponse As HttpResponse)

    '声明
    Dim lObjListModelList As New List(Of clsListColumnModelJsonStruct)
    Dim lObjColumnDataReaderlList As New List(Of clsColumnDataReaderJsonStruct)
    Dim lIntListViewCategory As Integer = 0
    Dim lLngListViewSrno As Long = 0

    Try
      '获得请求数据
      If IsNumeric(aObjRequest("prListViewCategory")) Then lIntListViewCategory = CInt(aObjRequest("prListViewCategory"))
      If IsNumeric(aObjRequest("prListViewSrno")) Then lLngListViewSrno = CLng(aObjRequest("prListViewSrno"))

    '生成回复值
      lObjListModelList = mObjColumnDefinationManager.mInitColumnModelStruct(Of clsListColumnModelJsonStruct)(lLngListViewSrno, lIntListViewCategory)
      lObjColumnDataReaderlList = mObjColumnDefinationManager.mInitColumnDataReaderStuct(lLngListViewSrno)
      If lObjListModelList.Count = 0 Or lObjColumnDataReaderlList.Count = 0 Then
        mObjResponseMessage.mPrpMessage = clsMessageDictionaryManager.mFnGetMessageDesc(1007, mIntGlobal_Language_Indc)
      Else
        mObjResponseMessage.mPrpMessageStatusIndc = clsResponseMessageStruct.EnmMessageStatusIndc.SUCCESS
        mObjResponseMessage.mPrpMessageBody = clsListColumnModelJsonStruct.ToJSONArray(lObjListModelList) & "," & _
                                              clsColumnDataReaderJsonStruct.ToJSONArray(lObjColumnDataReaderlList)
      End If
      aObjResponse.Write(mObjResponseMessage.ToJsonString)

      clsSystemMessageManager.mPrPushSystemMessage(clsSystemMessageStruct.EnmMessageType.DEBUG_INFO, " Response Context : " & mObjResponseMessage.ToJsonString, , clsSystemMessageStruct.EnmMessageLevel.DEBUG)
      clsLogManager.mPrLogAppInfo(clsLogMessagrStruct.EnmLogCategory.DEBUG_INFO, " Response Context : " & mObjResponseMessage.ToJsonString, clsLogMessagrStruct.EnmLogLevel.DEBUG)
    Catch ex As Exception
      Throw ex
    End Try
  End Sub

  ''' <summary>
  ''' 处理初始化列表类控件请求,返回列表值数据
  ''' 返回数据类型 Json 类型
  ''' </summary>
  ''' <param name="aObjRequest"></param>
  ''' <param name="aObjResponse"></param>
  ''' <remarks></remarks>
  Protected Sub mPrProcessInitLstControls(ByVal aObjRequest As HttpRequest, ByRef aObjResponse As HttpResponse)

    '声明
    Dim lObjList As New List(Of clsCodeMasterStruct)
    Dim lStrCodeDesc As String = String.Empty
    Dim lStrCustomQuery As String = String.Empty
    Dim lArrCodeDesc() As String = Nothing
    Dim lArrCustomQuery() As String = Nothing

    Try
      '获得请求数据
      If IsNothing(aObjRequest("prCodeMasterDesc")) = False Then lStrCodeDesc = aObjRequest("prCodeMasterDesc")
      If IsNothing(aObjRequest("prCustomQuery")) = False Then lStrCustomQuery = aObjRequest("prCustomQuery")
      lArrCodeDesc = lStrCodeDesc.Split("|")
      lArrCustomQuery = lStrCustomQuery.Split("|")

      '生成回复值
      For lIntIndex As Integer = 0 To lArrCodeDesc.Length - 1
        lObjList = mObjCodeMasterManager.mInitLstCodeStuct(lArrCodeDesc(lIntIndex), lArrCustomQuery(lIntIndex))
        If lObjList.Count = 0 Then
          mObjResponseMessage.mPrpMessage = clsMessageDictionaryManager.mFnGetMessageDesc(1007, mIntGlobal_Language_Indc)
        Else
          mObjResponseMessage.mPrpMessageStatusIndc = clsResponseMessageStruct.EnmMessageStatusIndc.SUCCESS
          If lIntIndex = 0 Then
            mObjResponseMessage.mPrpMessageBody = clsCodeMasterStruct.ToJSONArray(lObjList)
          Else
            mObjResponseMessage.mPrpMessageBody = mObjResponseMessage.mPrpMessageBody & "," & clsCodeMasterStruct.ToJSONArray(lObjList)
          End If

        End If
      Next
      aObjResponse.Write(mObjResponseMessage.ToJsonString)

      clsSystemMessageManager.mPrPushSystemMessage(clsSystemMessageStruct.EnmMessageType.DEBUG_INFO, " Response Context : " & mObjResponseMessage.ToJsonString, , clsSystemMessageStruct.EnmMessageLevel.DEBUG)
      clsLogManager.mPrLogAppInfo(clsLogMessagrStruct.EnmLogCategory.DEBUG_INFO, " Response Context : " & mObjResponseMessage.ToJsonString, clsLogMessagrStruct.EnmLogLevel.DEBUG)
    Catch ex As Exception
      Throw ex
    End Try
  End Sub

End Class
