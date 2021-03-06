﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<%--****************** All code and layout by Maggy Maffia, 09/2013 *******************--%>

<head runat="server">
    <title>Feed Me Hash: Better than the average Twitter search tool</title>
    <link href="style.css" rel="stylesheet" type="text/css" />
    <link href="favicon.ico" rel="icon" type="image/x-icon" />
</head>

<body>
    <form id="form1" runat="server">
        
        
        <%--Required for use of AJAX Control Toolkit --%>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
        
        <%--Background design--%>
        <div id="top_left"></div>
        <div id="bottom_left"></div>
        <div id="bottom_right"></div>
        <div id="top_right"></div>

        
        <div id="outer_div">
        
        <asp:UpdatePanel ID="search_updatePnl" runat="server">
        
            <ContentTemplate>
                
                <%--Init panel--%>
                <asp:Panel ID="initSearch_pnl" runat="server">
                    <table id="center_outer_table">
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
                <%--/Init panel--%>
                
                <%--Results panel--%>
                <asp:Panel ID="result_pnl" runat="server" Visible="false">
                
                    <table id="blank_outer_table">
                        <tr>
                            <td class="NameImageLeft">&nbsp;</td>
                        </tr>
                    </table>
                
                    <table id="outer_table">
                        <tr>
                            <td>
                                
                                <table class="options_area">
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="search_txt" runat="server" CssClass="HashInputStyle" Width="92%" />
                                            <asp:TextBoxWatermarkExtender ID="search_twExt" runat="server" WatermarkText="Hashtag(s)" TargetControlID="search_txt" />
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="go_lBtn" runat="server" CssClass="GoLinkBtnSmall" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <span class="Divider">&nbsp;</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            <asp:TextBox ID="filter_txt" runat="server" CssClass="InputStyle" Width="94%" />
                                            <asp:TextBoxWatermarkExtender ID="filter_twExt" runat="server" WatermarkText="Filter" TargetControlID="filter_txt" />
                                        </td>
                                        <td>
                                            <br />
                                            <asp:LinkButton ID="goFilter_lBtn" runat="server" CssClass="GoLinkBtnSmall" />
                                        </td>
                                        <td align="right">
                                            <br />
                                            <b>Sort by:</b>&nbsp;&nbsp;
                                            <asp:DropDownList ID="sort_ddl" runat="server" CssClass="DDLStyle" AutoPostBack="true" Width="200px">
                                                <asp:ListItem Text="Date (descending)" Value="0" />
                                                <asp:ListItem Text="Date (ascending)" Value="1" />
                                                <asp:ListItem Text="Handle (descending)" Value="2" />
                                                <asp:ListItem Text="Handle (ascending)" Value="3" />
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:Literal ID="resultHeader_lit" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="results_updatePnl" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:Repeater ID="results_repeater" runat="server">
                                            
                                                        <HeaderTemplate>
                                                            <table width="100%" class="TweetResultStyle">
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Literal ID="result_lit" runat="server" Text='<%#genResultItem(eval("User.Name"), eval("User.Identifier.ScreenName"), eval("Text"), eval("CreatedAt")) %>' />
                                                                    </td>
                                                                </tr>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </table>
                                                        </FooterTemplate>
                                                        
                                                    </asp:Repeater>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="go_lBtn" EventName="Click" />
                                                    <asp:AsyncPostBackTrigger ControlID="sort_ddl" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        
                                            <asp:Literal ID="indicator_lit" runat="server" />
                                        
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    
                    </table>
                
                </asp:Panel>
                <%--/Results panel--%>
                
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="initGo_lBtn" EventName="Click" />
            </Triggers>
        
        </asp:UpdatePanel>
        
        <%--Resources used info--%>
        <asp:ModalPopupExtender ID="resources_mpExt" runat="server" TargetControlID="dummy" PopupControlID="resources_pnl" />
        <input type="button" id="dummy" runat="server" style="display: none;" />
        
        <asp:Panel ID="resources_pnl" runat="server" CssClass="modalStyle" Width="350px">
            
            <asp:UpdatePanel ID="resources_updatePnl" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Literal ID="resources_lit" runat="server" />
                </ContentTemplate>
                
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="resources_lBtn" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="close_lBtn" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            
            <span style="text-align: center; width:100%; display: block;"><asp:LinkButton ID="close_lBtn" runat="server" Text="[Close]" CausesValidation="false" /></span>
        </asp:Panel>
        <%--/Resources used info--%>
            
            <div class="Footer">
                Copyright &copy; 2013, <a href="mailto:maggy@zogglet.com?subject=About your awesome Twitter search tool">Maggy Maffia</a> // <asp:LinkButton ID="resources_lBtn" runat="server" Text="Resources used" /> // <a href="http://www.zogglet.com" target="_blank">Zogglet.com</a>
            </div>
        
        
        </div>
    </form>
</body>
</html>
