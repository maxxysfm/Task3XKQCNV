(function()
{
 "use strict";
 var Global,Task3XKQCNV,Dto,Weight,User,Client,SC$1,WebSharper,UI,Var$1,Remoting,AjaxRemotingProvider,List,Charting,Chart,Pervasives,Doc,Renderers,ChartJs,AttrProxy,Seq,DateUtil,Operators,Date,IntelliFactory,Runtime;
 Global=self;
 Task3XKQCNV=Global.Task3XKQCNV=Global.Task3XKQCNV||{};
 Dto=Task3XKQCNV.Dto=Task3XKQCNV.Dto||{};
 Weight=Dto.Weight=Dto.Weight||{};
 User=Dto.User=Dto.User||{};
 Client=Task3XKQCNV.Client=Task3XKQCNV.Client||{};
 SC$1=Global.StartupCode$Task3XKQCNV$Client=Global.StartupCode$Task3XKQCNV$Client||{};
 WebSharper=Global.WebSharper;
 UI=WebSharper&&WebSharper.UI;
 Var$1=UI&&UI.Var$1;
 Remoting=WebSharper&&WebSharper.Remoting;
 AjaxRemotingProvider=Remoting&&Remoting.AjaxRemotingProvider;
 List=WebSharper&&WebSharper.List;
 Charting=WebSharper&&WebSharper.Charting;
 Chart=Charting&&Charting.Chart;
 Pervasives=Charting&&Charting.Pervasives;
 Doc=UI&&UI.Doc;
 Renderers=Charting&&Charting.Renderers;
 ChartJs=Renderers&&Renderers.ChartJs;
 AttrProxy=UI&&UI.AttrProxy;
 Seq=WebSharper&&WebSharper.Seq;
 DateUtil=WebSharper&&WebSharper.DateUtil;
 Operators=WebSharper&&WebSharper.Operators;
 Date=Global.Date;
 IntelliFactory=Global.IntelliFactory;
 Runtime=IntelliFactory&&IntelliFactory.Runtime;
 Weight.New=function(Username,Weight$1,Published)
 {
  return{
   Username:Username,
   Weight:Weight$1,
   Published:Published
  };
 };
 User.New=function(Username,Name,Password)
 {
  return{
   Username:Username,
   Name:Name,
   Password:Password
  };
 };
 Client.Main=function()
 {
  var rvLoginUsername,rvLoginName,rvLoginPassword,rvRegUsername,rvRegName,rvRegPassword,rvRegPasswordTry,rvLogPublished,rvLogWeight,data_unfinished,datafixed,chart;
  Var$1.Create$1("");
  rvLoginUsername=Var$1.Create$1("");
  rvLoginName=Var$1.Create$1("");
  rvLoginPassword=Var$1.Create$1("");
  rvRegUsername=Var$1.Create$1("");
  rvRegName=Var$1.Create$1("");
  rvRegPassword=Var$1.Create$1("");
  rvRegPasswordTry=Var$1.Create$1("");
  rvLogPublished=Var$1.Create$1((new Global.Date(Client.timeNow())).toLocaleString());
  rvLogWeight=Var$1.Create$1("5");
  data_unfinished=(new AjaxRemotingProvider.New()).Sync("Task3XKQCNV:Task3XKQCNV.Server.AllWeightsChart:-1363325819",[]);
  datafixed=List.map(function(x)
  {
   return[(new Global.Date(x.Published)).toLocaleString(),x.Weight];
  },data_unfinished);
  chart=Chart.Line$1(datafixed).__WithTitle("Square numbers").__WithFillColor(new Pervasives.Color({
   $:0,
   $0:120,
   $1:120,
   $2:120,
   $3:0.2
  }));
  return Doc.Element("div",[],[ChartJs.Render$8(chart,null,null,null),Doc.Element("table",[AttrProxy.Create("id","loginform"),AttrProxy.Create("border","2"),AttrProxy.Create("style","margin: auto;\n            width: 80%;\n            padding: 10px;\n            padding-bottom: 70px;\n            margin-bottom: 60px;")],List.ofSeq(Seq.delay(function()
  {
   var style;
   style=AttrProxy.Create("style","padding-top: 10px;padding-right: 10px;padding-bottom: 10px;padding-left: 10px;");
   return Seq.append([Doc.Element("th",[style],[Doc.Element("h2",[],[Doc.TextNode("Login")]),Doc.Element("table",[],[Doc.Element("tr",[],List.ofSeq(Seq.delay(function()
   {
    var displayText;
    displayText="Username: ";
    return Seq.append([Doc.Element("th",[],[Doc.Element("h3",[],[Doc.TextNode(displayText)])])],Seq.delay(function()
    {
     return[Doc.Element("th",[],[Doc.Input([AttrProxy.Create("placeholder",displayText)],rvLoginName)])];
    }));
   }))),Doc.Element("tr",[],List.ofSeq(Seq.delay(function()
   {
    var displayText;
    displayText="Password: ";
    return Seq.append([Doc.Element("th",[],[Doc.Element("h3",[],[Doc.TextNode(displayText)])])],Seq.delay(function()
    {
     return[Doc.Element("th",[],[Doc.Input([AttrProxy.Create("type","password"),AttrProxy.Create("placeholder",displayText)],rvLoginPassword)])];
    }));
   })))]),Doc.Button("Login",[],function()
   {
    var Login;
    Login=(new AjaxRemotingProvider.New()).Sync("Task3XKQCNV:Task3XKQCNV.Server.Login:-662090079",[rvLoginName.Get(),rvLoginPassword.Get()]);
    rvLoginName.Get()===""||rvLoginPassword.Get()===""?Global.alert("Please fill every field on the login screen."):Login!=null?(Global.alert("Welcome "+Login.$0.Name+"!"),self.document.getElementById("loginform").setAttribute("style","display:none"),self.document.getElementById("homepage").setAttribute("style","display:block"),rvLoginUsername.Set(Login.$0.Name)):Global.alert("Invalid username or password!");
   })])],Seq.delay(function()
   {
    return[Doc.Element("th",[style],[Doc.Element("h2",[],[Doc.TextNode("Register")]),Doc.Element("table",[],[Doc.Element("tr",[],List.ofSeq(Seq.delay(function()
    {
     var displayText;
     displayText="Username: ";
     return Seq.append([Doc.Element("th",[],[Doc.Element("h3",[],[Doc.TextNode(displayText)])])],Seq.delay(function()
     {
      return[Doc.Element("th",[],[Doc.Input([AttrProxy.Create("placeholder",displayText)],rvRegName)])];
     }));
    }))),Doc.Element("tr",[],List.ofSeq(Seq.delay(function()
    {
     var displayText;
     displayText="Display Name: ";
     return Seq.append([Doc.Element("th",[],[Doc.Element("h3",[],[Doc.TextNode(displayText)])])],Seq.delay(function()
     {
      return[Doc.Element("th",[],[Doc.Input([AttrProxy.Create("placeholder",displayText)],rvRegUsername)])];
     }));
    }))),Doc.Element("tr",[],List.ofSeq(Seq.delay(function()
    {
     var displayText;
     displayText="Password: ";
     return Seq.append([Doc.Element("th",[],[Doc.Element("h3",[],[Doc.TextNode(displayText)])])],Seq.delay(function()
     {
      return[Doc.Element("th",[],[Doc.Input([AttrProxy.Create("type","password"),AttrProxy.Create("placeholder",displayText)],rvRegPassword)])];
     }));
    }))),Doc.Element("tr",[],List.ofSeq(Seq.delay(function()
    {
     var displayText;
     displayText="Password again: ";
     return Seq.append([Doc.Element("th",[],[Doc.Element("h3",[],[Doc.TextNode(displayText)])])],Seq.delay(function()
     {
      return[Doc.Element("th",[],[Doc.Input([AttrProxy.Create("type","password"),AttrProxy.Create("placeholder",displayText)],rvRegPasswordTry)])];
     }));
    })))]),Doc.Button("Register",[],function()
    {
     if(rvRegName.Get()===""||rvRegUsername.Get()===""||rvRegPassword.Get()===""||rvRegPasswordTry.Get()==="")
      Global.alert("You must enter a value in every option!");
     else
      if(rvRegPassword.Get()!==rvRegPasswordTry.Get())
       Global.alert("Passwords doesn't match.");
      else
       if((new AjaxRemotingProvider.New()).Sync("Task3XKQCNV:Task3XKQCNV.Server.NameExists:1707812660",[rvRegName.Get()]))
        Global.alert("This username is not available! Pick a different username.");
       else
        {
         (new AjaxRemotingProvider.New()).Send("Task3XKQCNV:Task3XKQCNV.Server.Register:1351335016",[rvRegName.Get(),rvRegUsername.Get(),rvRegPassword.Get()]);
         Global.alert("Registered");
        }
    })])];
   }));
  }))),Doc.Element("div",[AttrProxy.Create("id","homepage"),AttrProxy.Create("style","display:none;padding-bottom: 20px;padding-top: 20px;")],[Doc.Element("table",[AttrProxy.Create("border","2"),AttrProxy.Create("style","margin: auto;\n                width: 80%;\n                padding: 10px;")],List.ofSeq(Seq.delay(function()
  {
   return[Doc.Element("th",[AttrProxy.Create("style","padding-top: 10px;padding-right: 10px;padding-bottom: 10px;padding-left: 10px;")],[Doc.Element("h2",[],[Doc.TextNode("Log your weight!")]),Doc.Element("table",[],[Doc.Element("tr",[],List.ofSeq(Seq.delay(function()
   {
    return Seq.append([Doc.Element("th",[],[Doc.Element("h3",[],[Doc.TextNode("Your name: ")])])],Seq.delay(function()
    {
     return[Doc.Element("th",[],[Doc.Input([AttrProxy.Create("disabled","")],rvLoginUsername)])];
    }));
   }))),Doc.Element("tr",[],List.ofSeq(Seq.delay(function()
   {
    return Seq.append([Doc.Element("th",[],[Doc.Element("h3",[],[Doc.TextNode("Weight to log: ")])])],Seq.delay(function()
    {
     return[Doc.Element("th",[],[Doc.Input([AttrProxy.Create("type","number"),AttrProxy.Create("min","1"),AttrProxy.Create("max","500")],rvLogWeight)])];
    }));
   }))),Doc.Element("tr",[],[Doc.Element("th",[],[Doc.Element("h3",[],[Doc.TextNode("")])]),Doc.Element("th",[],[Doc.Input([AttrProxy.Create("disabled",""),AttrProxy.Create("value",rvLogPublished.Get())],rvLogPublished)])]),Doc.Element("tr",[],[Doc.Element("th",[],[Doc.Element("h3",[],[Doc.TextNode("Date")])]),Doc.Element("th",[],[Doc.Input([AttrProxy.Create("type","date"),AttrProxy.Create("min","1980-01-01"),AttrProxy.Create("max","2100-01-01"),AttrProxy.Create("value",rvLogPublished.Get())],rvLogPublished)])])]),Doc.Button("Log weight!",[],function()
   {
    var theDate;
    if(rvLogPublished.Get()===""||rvLogWeight.Get()==="")
     Global.alert("You must enter a value in every option!");
    else
     {
      theDate=DateUtil.Parse(rvLogPublished.Get());
      (new AjaxRemotingProvider.New()).Send("Task3XKQCNV:Task3XKQCNV.Server.AddWeight:38517317",[rvLoginUsername.Get(),Operators.toInt(Global.Number(rvLogWeight.Get())),theDate]);
      Global.alert("Weight logged!");
      chart.__UpdateData(50,function()
      {
       return Global.Number(rvLogWeight.Get());
      });
     }
   })])];
  })))])]);
 };
 Client.timeNow=function()
 {
  SC$1.$cctor();
  return SC$1.timeNow;
 };
 SC$1.$cctor=function()
 {
  SC$1.$cctor=Global.ignore;
  SC$1.timeNow=Date.now();
 };
 Runtime.OnLoad(function()
 {
  Client.Main();
 });
}());
