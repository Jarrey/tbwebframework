// Mangager Main Dojo JavaScript File
/*全局设置开始*/
//载入Dojo组件包
dojo.require("dijit.dijit"); // loads the optimized dijit layer
dojo.require("dojo.data.ItemFileReadStore");
dojo.require("dijit.Tree");
//加载 初始化
dojo.addOnLoad(function(){if(window.pub) window.pub();});
/*全局设置结束*/

/* 数据声明开始 */
/* 数据声明结束 */

var jsObjManagerMain = {

  evthandles:                  [],   //事件句柄集
  mRequest:                    null,
  mstoreMenu:                  null, //菜单数据集
  mforestStoreMenu:            null, //菜单树数据集
  mmenuTree:                   null, //菜单树
  
//Initialize
initialize: function(){
  //实例化成员
  this.mRequest                = new jsClsRequest("ManagerMainServer.aspx", this);
  //事件绑定
  dojo.forEach(this.evthandles, dojo.disconnect);
  //初始化控件数据
  this.mFnPopulateCcontrolData();
},

mFnPopulateCcontrolData: function(){
  //菜单初始化
  var menuParams = {prRequestIndc: this.mRequest.CNST_RQ_INDC.RQ_INIT_MENU,
                    prMenuCategory: 1};
  this.mRequest.RequestToServer(menuParams, function(response){
    this.mstoreMenu = new dojo.data.ItemFileReadStore({data: response.jsMessageBody[0]});
    this.mforestStoreMenu = new dijit.tree.ForestStoreModel({
      store: this.mstoreMenu,
      query: {"jsMenuCategory": 1},
      childrenAttrs: ["jsChildren"]});
    this.mmenuTree = new dijit.Tree({model: this.mforestStoreMenu, 
                                     showRoot: false, 
                                     openOnClick: true},"menuTree");
    this.evthandles.push(dojo.connect(this.mmenuTree,"onClick",this,this.mEvtOnClick_mmenuTree));
  });
},

/*事件开始*/
//菜单树单击事件
mEvtOnClick_mmenuTree: function(item){window.open(item.jsURL,item.jsTarget);}
/*事件结束*/
};
//初始化对象
dojo.addOnLoad(jsObjManagerMain,jsObjManagerMain.initialize);