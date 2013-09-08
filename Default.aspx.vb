Imports System.Net
Imports System.IO
Imports Tweet
Imports LinqToTwitter
Imports System.Linq
Imports System.Web


Partial Class _Default
    Inherits System.Web.UI.Page

    Private auth As WebAuthorizer
    Private twitCtxt As TwitterContext


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim credentials As IOAuthCredentials = New SessionStateCredentials()

            If credentials.ConsumerKey Is Nothing Or credentials.ConsumerSecret Is Nothing Then
                credentials.ConsumerKey = ConfigurationManager.AppSettings("TwitterConsumerKey")
                credentials.ConsumerSecret = ConfigurationManager.AppSettings("TwitterConsumerSecret")
            End If

            Dim authURL As Action(Of String) = AddressOf Response.Redirect
            auth = New WebAuthorizer()
            auth = New WebAuthorizer With {.Credentials = credentials, .PerformRedirect = authURL}

            If Not Page.IsPostBack Then
                auth.CompleteAuthorization(Request.Url)
            End If

        Catch ex As Exception
            Throw ex
        End Try



    End Sub


    Protected Sub initGo_lBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles initGo_lBtn.Click

        Try
            auth.BeginAuthorization(Request.Url)
        Catch ex As Exception
            Throw ex
        End Try



        initSearch_pnl.Visible = False
        result_pnl.Visible = True

        Dim htQuery As String = IIf(initSearch_txt.Text.Contains("#"), initSearch_txt.Text.Trim.Replace("#", "%23"), "%23" & initSearch_txt.Text.Trim)

        'LEFT OFF HERE, 09/07/2013: Try the previous JS serializer stuff after authorization is over with

        Dim oAuthHeader As String = "OAuth oauth_consumer_key=""IS312SbQ6aeJw5Sr0bdA"", oauth_nonce=""3cd03915232f3c0418d5fa4b2423a19e"", oauth_signature=""KTNx3fmVFvUmJ999ocaIftr%2FPZQ%3D"", oauth_signature_method=""HMAC-SHA1"", oauth_timestamp=""1378241338"", oauth_token=""16176622-V6N2ZfwrX5mZ83e1m1PIpoUIUyJWAVugrPwhCODYT"", oauth_version=""1.0"""
        Dim strBuilder As StringBuilder = New StringBuilder()

        ServicePointManager.Expect100Continue = False

        Dim theRequest As HttpWebRequest = CType(WebRequest.Create("https://api.twitter.com/1.1/search/tweets.json?q=" & htQuery), HttpWebRequest)
        theRequest.Headers.Add("Authorization", oAuthHeader)
        theRequest.Method = "GET"
        theRequest.ContentType = "application/x-www-form-urlencoded"

        'Using stream As Stream = request.GetRequestStream()
        ' Dim content As Byte() = ASCIIEncoding.ASCII.GetBytes(
        'End Using







        Dim response As HttpWebResponse = CType(theRequest.GetResponse, HttpWebResponse)

        Dim rspStream As Stream = response.GetResponseStream()
        Dim reader As StreamReader = New StreamReader(rspStream)
        Dim jsonStr As String = reader.ReadToEnd()










        'Using db = New TwitterContext(auth)

        '    Dim search As Search = db.Search.Where(Function(s) s.Type = SearchType.Search AndAlso s.Query = "#dog").[SingleOrDefault]()

        '    Dim searchResults = (From search In twitCtxt.Search Where search.Type = SearchType.Search AndAlso search.hashtag = tagsearch).singleOrDefault()
        '    Dim list As List = search.results.tolist()


        ' End Using


    End Sub



End Class
