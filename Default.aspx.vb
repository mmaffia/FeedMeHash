Imports System.Net
Imports System.IO
Imports Tweet
Imports LinqToTwitter
Imports System.Linq
Imports System.Web

Partial Class _Default
    Inherits System.Web.UI.Page

    'Private auth As SingleUserAuthorizer
    Private auth As ApplicationOnlyAuthorizer
    Private twitCtxt As TwitterContext


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            auth = New ApplicationOnlyAuthorizer() With { _
                .Credentials = New InMemoryCredentials() With { _
                .ConsumerKey = ConfigurationManager.AppSettings("TwitterConsumerKey"), _
                .ConsumerSecret = ConfigurationManager.AppSettings("TwitterConsumerSecret") _
                } _
            }

        Catch ex As Exception
            Throw ex
        End Try



    End Sub


    Protected Sub initGo_lBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles initGo_lBtn.Click

        Try
            auth.Authorize()


            initSearch_pnl.Visible = False
            result_pnl.Visible = True

            Dim htQuery As String = IIf(initSearch_txt.Text.Contains("#"), initSearch_txt.Text.Trim.Replace("#", "%23"), "%23" & initSearch_txt.Text.Trim)

            Dim twitCtxt As TwitterContext = New TwitterContext(auth)


            Dim srch = (From search In twitCtxt.Search Where search.Type = SearchType.Search And search.Query = htQuery Select search).SingleOrDefault
            Dim resultsList As Generic.List(Of Status) = srch.Statuses

            results_repeater.DataSource = resultsList
            results_repeater.DataBind()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub



End Class
