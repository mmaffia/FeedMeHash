Imports System.Net
Imports System.Web.Script.Serialization
Imports System.IO
Imports Tweet

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub initGo_lBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles initGo_lBtn.Click

        initSearch_pnl.Visible = False
        result_pnl.Visible = True

        Try

            'Dim oAuthToken As String = "16176622-V6N2ZfwrX5mZ83e1m1PIpoUIUyJWAVugrPwhCODYT"
            'Dim oAuthTokenSecret As String = "YLBlhCM5yqIXOut6kfNxmo89aR8Ab8EEKNXxlsqgY"
            'Dim oAuthConsumerKey As String = "IS312SbQ6aeJw5Sr0bdA"
            'Dim oAuthConsumerSecret As String = "yWjds2SGTOj52NsMJcrp7zKQBAx85IRRrVkuExte3g"
            'Dim oAuthVersion As String = "1.0"
            'Dim oAuthSigMethod As String = "HMAC-SHA1"
            'Dim oAuthSig As String = "ZWRp%2BFlocSL2PhlceSQ%2F07IVmJ8%3D"
            'Dim oAuthNOnce As String = "748ff21db729a953c72f11262a17bebb"
            'Dim timeStamp As String = "1378238550"
            'Dim timeSpan As TimeSpan = DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
            'Dim resourceUrl As String = "https://api.twitter.com/1.1/search/tweets.json"




            Dim oAuthHeader As String = "OAuth oauth_consumer_key=""IS312SbQ6aeJw5Sr0bdA"", oauth_nonce=""3cd03915232f3c0418d5fa4b2423a19e"", oauth_signature=""KTNx3fmVFvUmJ999ocaIftr%2FPZQ%3D"", oauth_signature_method=""HMAC-SHA1"", oauth_timestamp=""1378241338"", oauth_token=""16176622-V6N2ZfwrX5mZ83e1m1PIpoUIUyJWAVugrPwhCODYT"", oauth_version=""1.0"""

            Dim htQuery As String = IIf(initSearch_txt.Text.Contains("#"), initSearch_txt.Text.Trim.Replace("#", "%23"), "%23" & initSearch_txt.Text.Trim)


            Dim strBuilder As StringBuilder = New StringBuilder()

            ServicePointManager.Expect100Continue = False

            Dim request As HttpWebRequest = CType(WebRequest.Create("https://api.twitter.com/1.1/search/tweets.json?q=" & htQuery), HttpWebRequest)
            request.Headers.Add("Authorization", oAuthHeader)
            request.Method = "GET"
            request.ContentType = "application/x-www-form-urlencoded"

            'Using stream As Stream = request.GetRequestStream()
            '    Dim content As Byte() = ASCIIEncoding.ASCII.GetBytes(
            'End Using







            Dim response As HttpWebResponse = CType(request.GetResponse, HttpWebResponse)

            Dim rspStream As Stream = response.GetResponseStream()
            Dim reader As StreamReader = New StreamReader(rspStream)
            Dim jsonStr As String = reader.ReadToEnd()



            Dim jsSerializer As JavaScriptSerializer = New JavaScriptSerializer()
            Dim theTweet As Tweet = jsSerializer.Deserialize(Of Tweet)(jsonStr)


        Catch ex As Exception
            Throw ex
        End Try



    End Sub
End Class
