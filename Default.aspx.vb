Imports System.Net
Imports System.IO
Imports Tweet
Imports LinqToTwitter
Imports System.Linq
Imports System.Web

Partial Class _Default
    Inherits System.Web.UI.Page

    Private auth As ApplicationOnlyAuthorizer
    Private twitCtxt As TwitterContext


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session.Clear()
        End If

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


    Public Function genResultItem(ByVal name As Object, ByVal id As Object, ByVal text As Object, ByVal createdAt As Object) As String
        Dim everythingStr As String = ""

        everythingStr = "<h2>" & name & " (@" & id & ")</h2>" & _
                        "<p>" & text & "</p>" & _
                        "<p class='ItemDateStyle'>" & CDate(createdAt).ToShortDateString() & ", " & CDate(createdAt).ToShortTimeString() & "</p>"

        Return everythingStr

    End Function


    Protected Sub initGo_lBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles initGo_lBtn.Click

        initSearch_pnl.Visible = False
        result_pnl.Visible = True

        Dim htQuery As String = IIf(initSearch_txt.Text.Contains("#"), initSearch_txt.Text.Trim.Replace("#", "%23"), "%23" & initSearch_txt.Text.Trim)

        processSearch(htQuery)

    End Sub

    Private Sub processSearch(ByVal searchTerm As String)

        Try
            auth.Authorize()

            Dim twitCtxt As TwitterContext = New TwitterContext(auth)


            Dim srch = (From search In twitCtxt.Search Where search.Type = SearchType.Search And search.Query = searchTerm Select search).SingleOrDefault()
            Dim resultsList As Generic.List(Of Status) = srch.Statuses

            If srch.Statuses.Count = 0 Then
                indicator_lit.Text = "<span class='NoDataStyle'>D'oh! Sorry, no recent tweets contain that hashtag. Try again!</span>"
            Else
                indicator_lit.Text = ""

                Session("CurrentSearch") = resultsList

                results_repeater.DataSource = resultsList
                results_repeater.DataBind()

                resultHeader_lit.Text = "<h3>Results for <i>'" & searchTerm.Remove(0, 3) & "'</i></h3>"

            End If


        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Protected Sub go_lBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles go_lBtn.Click

        Dim htQuery As String = IIf(search_txt.Text.Contains("#"), search_txt.Text.Trim.Replace("#", "%23"), "%23" & search_txt.Text.Trim)

        processSearch(htQuery)
        results_updatePnl.Update()

    End Sub

    Protected Sub goFilter_lBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles goFilter_lBtn.Click
        Dim currentResults As Generic.List(Of Status) = Session("CurrentSearch")
        Dim newSearch = (From p In currentResults Where p.Text.Contains(filter_txt.Text.Trim))

        results_repeater.DataSource = newSearch
        results_repeater.DataBind()

        results_updatePnl.Update()

    End Sub

    Protected Sub sort_ddl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles sort_ddl.SelectedIndexChanged
        Dim currentResults As Generic.List(Of Status) = Session("CurrentSearch")
        Dim sortedSearch = (From p In currentResults Order By p.CreatedAt Descending)

        Select Case sort_ddl.SelectedValue
            Case 0
                sortedSearch = (From p In currentResults Order By p.CreatedAt Descending)
            Case 1
                sortedSearch = (From p In currentResults Order By p.CreatedAt Ascending)
            Case 2
                sortedSearch = (From p In currentResults Order By p.User.Identifier.ScreenName Descending)
            Case 3
                sortedSearch = (From p In currentResults Order By p.User.Identifier.ScreenName Ascending)
        End Select

        results_repeater.DataSource = sortedSearch
        results_repeater.DataBind()

        results_updatePnl.Update()
    End Sub
End Class
