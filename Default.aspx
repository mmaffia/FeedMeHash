<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Feed Me Hash: Better than the average Twitter search tool</title>
    <link href="style.css" rel="stylesheet" type="text/css" />
    
</head>

<body>
    <form id="form1" runat="server">
        
        
        <%--Required for use of AJAX Control Toolkit --%>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
        
        <div id="outer_div">
        
        <asp:UpdatePanel ID="search_updatePnl" runat="server">
        
            <ContentTemplate>
                <asp:Panel ID="initSearch_pnl" runat="server">
                    <table id="blank_outer_table">
                        <tr>
                            <td class="NameImage" colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="InitControls">
                                <asp:TextBox ID="initSearch_txt" runat="server" CssClass="InitInputStyle" Width="260px" />&nbsp;&nbsp;
                                <asp:TextBoxWatermarkExtender ID="initSearch_twExt" runat="server" WatermarkText="Hashtag" TargetControlID="initSearch_txt" />
                            </td>
                            <td>
                                <asp:LinkButton ID="initGo_lBtn" runat="server" CssClass="GoLinkBtn" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                
                
                <asp:Panel ID="result_pnl" runat="server" Visible="false">
                
                    <table id="outer_table">
                        <tr>
                            <td>
                                
                                <table id="options_area">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="search_txt" runat="server" CssClass="InputStyle" Width="225px" />
                                            <asp:TextBoxWatermarkExtender ID="search_twExt" runat="server" WatermarkText="Hashtag" TargetControlID="search_txt" />
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="go_lBtn" runat="server" CssClass="GoLinkBtnSmall" />
                                        </td>
                                    </tr>
                                    
                                </table>
                                
                            </td>
                        </tr>
                    
                    </table>
                
                </asp:Panel>
                
                
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="initGo_lBtn" EventName="Click" />
            </Triggers>
        
        </asp:UpdatePanel>
        
        
            
            
            
            <div class="Footer">
                Copyright &copy; 2013, <a href="mailto:maggy@zogglet.com?subject=About your awesome Twitter search tool">Maggy Maffia</a> // <a href="#">Resources used</a> // <a href="http://www.zogglet.com" target="_blank">Zogglet.com</a>
            </div>
        
            <%--Background design--%>
            <div id="top_left"></div>
            <div id="bottom_left"></div>
            <div id="bottom_right"></div>
            <div id="top_right"></div>
            
            
        
        </div>
    </form>
</body>
</html>
