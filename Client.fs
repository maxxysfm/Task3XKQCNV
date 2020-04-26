namespace Task3XKQCNV

open WebSharper
open WebSharper.JavaScript
open WebSharper.UI
open WebSharper.UI.Client
open WebSharper.UI.Html
open WebSharper.Charting

[<JavaScript>]
module Client =

    let timeNow = System.DateTime.Now
    open Dto
    
    [<SPAEntryPoint>]
    let Main () =

        let data = [for x in 1.0 .. 9.0 -> (string x + "^2", x * x)]

        // Egy tökéletes világban, feltöltöm a chart adatait a lekérdezett értékekkel! :)        
        let data_unfinished = Server.AllWeightsChart

        let chart =
            Chart.Line(data)
              .WithTitle("Square numbers")
              .WithFillColor(Color.Rgba(120, 120, 120, 0.2))

        // Test
        let rvTEMP = Var.Create ""
        
        // Login system data, itt tároljuk az adatait az usernek később
        let rvLoginUsername = Var.Create ""
        let rvLoginName = Var.Create ""
        let rvLoginPassword = Var.Create ""
        
        // Regisztrálás
        let rvRegUsername = Var.Create ""
        let rvRegName = Var.Create ""
        let rvRegPassword = Var.Create ""
        let rvRegPasswordTry = Var.Create ""
        
        // Belépés utáni adatok

        let rvLogPublished = Var.Create (string timeNow)
        let rvLogWeight = Var.Create "5"

        div [] [
            
            chart |> Renderers.ChartJs.Render



            table [
            attr.``id`` "loginform"
            attr.``border`` "2"
            attr.``style`` "margin: auto;
            width: 80%;
            padding: 10px;
            padding-bottom: 70px;
            margin-bottom: 60px;"
            ] [
                let style = attr.``style`` "padding-top: 10px;padding-right: 10px;padding-bottom: 10px;padding-left: 10px;"
                th[style] [
                
                    // Login form
                    h2 [] [text "Login"]
                    table [] [
                        tr [][
                            let displayText =  "Username: "
                            th [] [
                                h3 [] [text displayText]
                                ]                    
                            th [] [
                                Doc.Input [attr.``placeholder`` displayText] rvLoginName
                                ]
                        ]
                        tr [][
                            let displayText =  "Password: "
                            th [] [
                                h3 [] [text displayText]
                                ]                    
                            th [] [
                                Doc.Input [
                                attr.``type`` "password"
                                attr.``placeholder`` displayText
                                    ] rvLoginPassword
                                ]
                        ]
                    ]
                    Doc.Button "Login" [] (fun _ ->
                        let Login = Server.Login(rvLoginName.Value,rvLoginPassword.Value)
                        if (rvLoginName.Value = "" || rvLoginPassword.Value = "") then
                            JS.Alert("Please fill every field on the login screen.")
                        elif (Login.IsSome) then 
                            JS.Alert("Welcome " + Login.Value.Name + "!")
                            JS.Document.GetElementById("loginform").SetAttribute("style","display:none");
                            JS.Document.GetElementById("homepage").SetAttribute("style","display:block");

                            // Adatok frontendre feltöltése
                            rvLoginUsername.Value <- Login.Value.Name
                        else
                            JS.Alert("Invalid username or password!")
                    )
                ]
                th[style] [
                    h2 [] [text "Register"]
                    table [] [
                        tr [][
                            let displayText =  "Username: "
                            th [] [
                                h3 [] [text displayText]
                                ]                    
                            th [] [
                                Doc.Input [attr.``placeholder`` displayText] rvRegName
                                ]
                        ]
                        tr [][
                            let displayText =  "Display Name: "
                            th [] [
                                h3 [] [text displayText]
                                ]                    
                            th [] [
                                Doc.Input [attr.``placeholder`` displayText] rvRegUsername
                                ]
                        ]
                        tr [][
                            let displayText =  "Password: "
                            th [] [
                                h3 [] [text displayText]
                                ]                    
                            th [] [
                                Doc.Input [
                                attr.``type`` "password"
                                attr.``placeholder`` displayText
                                    ] rvRegPassword
                                ]
                        ]
                        tr [][
                            let displayText =  "Password again: "
                            th [] [
                                h3 [] [text displayText]
                                ]                    
                            th [] [
                                Doc.Input [
                                attr.``type`` "password"
                                attr.``placeholder`` displayText
                                    ] rvRegPasswordTry
                                ]
                        ]
                    ]       
            
                    // Hozzáadás gomb megnézi a textboxok értékeit
                    Doc.Button "Register" [] (fun _ ->
                    if(rvRegName.Value = "" || rvRegUsername.Value = "" || rvRegPassword.Value = "" || rvRegPasswordTry.Value = "") then
                        JS.Alert("You must enter a value in every option!");
                    else
                        if(rvRegPassword.Value <> rvRegPasswordTry.Value) then JS.Alert("Passwords doesn't match.")
                        else
                            if(Server.NameExists(rvRegName.Value)) then JS.Alert("This username is not available! Pick a different username.")
                            else 
                                Server.Register(rvRegName.Value,rvRegUsername.Value,rvRegPassword.Value)
                                JS.Alert("Registered")
                    )
                ]
            ]
            
            // Belépés utáni tábla
            div [
                attr.``id`` "homepage"
                attr.``style`` "display:none;padding-bottom: 20px;padding-top: 20px;"
            ] [
            
            //h1 [] [Doc.Input [attr.``disabled`` ""] rvLoginName]
            //h1 [] [Doc.Input [attr.``disabled`` ""] rvLoginUsername]
            //h1 [] [Doc.Input [attr.``disabled`` ""] rvLoginPassword]
            table [
                attr.``border`` "2"
                attr.``style`` "margin: auto;
                width: 80%;
                padding: 10px;"
            ] [
                let style = attr.``style`` "padding-top: 10px;padding-right: 10px;padding-bottom: 10px;padding-left: 10px;"
                th[style] [
                    h2 [] [text "Log your weight!"]
                    table [] [
                        tr [][
                            let displayText =  "Your name: "
                            th [] [
                                h3 [] [text displayText]
                                ]                    
                            th [] [
                                Doc.Input [attr.``disabled`` ""] rvLoginUsername
                                ]
                        ]
                        tr [][
                            let displayText =  "Weight to log: "
                            th [] [
                                h3 [] [text displayText]
                                ]                    
                            th [] [
                                Doc.Input [
                                    attr.``type`` "number"
                                    attr.``min`` "1"
                                    attr.``max`` "500"
                                    ] rvLogWeight
                                ]
                        ]
                        tr [][
                            th [] [
                                h3 [] [text ""]
                                ]                    
                            th [] [
                                Doc.Input [
                                attr.``disabled`` ""
                                attr.``value`` rvLogPublished.Value
                                    ] rvLogPublished
                                ]
                        ]
                        tr [][
                            th [] [
                                h3 [] [text "Date"]
                                ]                    
                            th [] [
                                Doc.Input [
                                attr.``type`` "date"
                                attr.``min`` "1980-01-01"
                                attr.``max`` "2100-01-01"
                                attr.``value`` rvLogPublished.Value
                                    ] rvLogPublished
                                ]
                        ]
                    ]       
            
                    // Hozzáadás gomb megnézi a textboxok értékeit
                    Doc.Button "Log weight!" [] (fun _ ->
                    if(rvLogPublished.Value = "" || rvLogWeight.Value = "") then
                        JS.Alert("You must enter a value in every option!")
                    else
                        let theDate = System.DateTime.Parse(rvLogPublished.Value)
                        Server.AddWeight(rvLoginUsername.Value,(int rvLogWeight.Value),theDate)
                        JS.Alert("New book added!")
                    )
                ]
            ]
            
            // Tábla kirajzolás
            //hr [] []
            //h3 [] [text "List of books! (Make sure to Refresh!)"]
            //Doc.Button "Refresh" [] (fun _ -> JS.Alert(""))
 
            //div [attr.``class`` "jumbotron"] [b [] [
            //textView vReversed
            //]]
            ]
        ]