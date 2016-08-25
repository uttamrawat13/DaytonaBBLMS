<%@ Page Title="" Language="C#" MasterPageFile="~/DSISLMS_Main.Master" AutoEventWireup="true" CodeBehind="frmschedule.aspx.cs" Inherits="DSISLMS_Web.frmschedule" %>
<asp:Content ID="ConCPHDetail" ContentPlaceHolderID="CPHDetail" runat="server">

    <telerik:RadAjaxLoadingPanel ID="RALPfrmSMSconfiguration" runat="server" Height="75px"
        Width="75px" Transparency="50">
    </telerik:RadAjaxLoadingPanel>
     

     <telerik:RadAjaxManagerProxy ID="RAMfrmSMSconfiguration" runat="server">
      <AjaxSettings>
       <telerik:AjaxSetting AjaxControlID="PfrmSMSconfiguration">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="PfrmSMSconfiguration" LoadingPanelID="RALPfrmSMSconfiguration" ></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <asp:Panel runat="server" ID="PfrmSMSconfiguration">
       <telerik:RadPageLayout runat="server" ID="RDPLayoutfrmSMSconfiguration" GridType="Fluid">
              <Rows>
                    <telerik:LayoutRow ID="LR"   runat="server"  >
                        <Columns>
                            
                             <telerik:LayoutColumn   Span="6"   SpanXs="12"  SpanMd="6"  SpanSm="6">
                             
                                   <telerik:RadPageLayout runat="server" ID="RDPLayoutCreateEmailConfiguation" GridType="Fluid">
                                       <Rows>
                                            <telerik:LayoutRow  ID="LRRlblSMSconfigResulut" runat="server" Visible="false" style="margin-top:4px;margin-left:2px;margin-right:2px">
                                                <Columns>
                                                        <telerik:LayoutColumn   Span="12"  SpanXs="12" SpanSm="12" >
                                                           <telerik:RadLabel ID="RlblSMSconfigResulut" runat="server" ForeColor="#cc0000"></telerik:RadLabel>
                                                        </telerik:LayoutColumn> 
                                                </Columns>
                                            </telerik:LayoutRow>
                                       </Rows>    
                                       <Rows>
                                            <telerik:LayoutRow style="margin-top:4px;margin-left:2px;margin-right:2px" >
                                                <Columns>
                                                    <telerik:LayoutColumn   Span="2"  SpanXs="2" SpanSm="2" >
                                                         <b>Schedule Title</b> 
                                                    </telerik:LayoutColumn>
                                                     <telerik:LayoutColumn   Span="10"  SpanXs="10" SpanSm="10" >
                                                        <telerik:RadTextBox RenderMode="Lightweight" runat="server"   ID="RTBScheduleTitle" Width="100%">
                                                        </telerik:RadTextBox>
                                                        <asp:RequiredFieldValidator ID="RFVRTBScheduleTitle" runat="server" Display="Dynamic" ValidationGroup="VGSMSConfig"
                                                        ControlToValidate="RTBScheduleTitle" ErrorMessage="Please Enter Schedule Title" ForeColor="Red" />
                                                     </telerik:LayoutColumn>
                                                </Columns>
                                            </telerik:LayoutRow>
                                       </Rows>
                                       <Rows>
                                            <telerik:LayoutRow style="margin-top:4px;margin-left:2px;margin-right:2px">
                                                <Columns>
                                                    <telerik:LayoutColumn   Span="2"  SpanXs="2" SpanSm="2" >
                                                        <b>Start Time</b> 
                                                    </telerik:LayoutColumn>
                                                     <telerik:LayoutColumn   Span="10"  SpanXs="10" SpanSm="10" >
                                                            <telerik:RadDateTimePicker RenderMode="Lightweight" ID="RadDateTimePicker1" Width="100%" runat="server" DateInput-CssClass="radPreventDecorate">
                                                            </telerik:RadDateTimePicker>
                                                    </telerik:LayoutColumn> 
                                                </Columns>
                                            </telerik:LayoutRow>
                                        </Rows>
                                           <Rows>
                                            <telerik:LayoutRow ID="LayoutRow10"    runat="server"   style="margin-top:4px;margin-left:2px;margin-right:2px">
                                                <Columns>
                                                    <telerik:LayoutColumn   Span="2"  SpanXs="2" SpanSm="2" >
                                                         <b>End Time</b>
                                                    </telerik:LayoutColumn>
                                                     <telerik:LayoutColumn   Span="10"  SpanXs="10" SpanSm="10" >
                                                         <telerik:RadDateTimePicker RenderMode="Lightweight" ID="RadDateTimePicker2" ShowPopupOnFocus="true" Width="100%" runat="server" DateInput-CssClass="radPreventDecorate">
                                                         </telerik:RadDateTimePicker>
                                                    </telerik:LayoutColumn> 
                                                </Columns>
                                            </telerik:LayoutRow>
                                        </Rows>
                                   
                                       <Rows>
                                            <telerik:LayoutRow ID="LayoutRow1"    runat="server"   style="margin-top:4px;margin-left:2px;margin-right:2px">
                                                <Columns>
                                                    <telerik:LayoutColumn   Span="2"  SpanXs="2" SpanSm="2" >
                                                         <b>Module</b>
                                                    </telerik:LayoutColumn>
                                                     <telerik:LayoutColumn   Span="10"  SpanXs="10" SpanSm="10" >
                                                         <div style="border:1px solid;padding:2px">
                                                                            <asp:CheckBoxList ID="CheckBoxList1" runat="server"  RepeatDirection="Horizontal" >  
                                                                                <asp:ListItem>User</asp:ListItem>  
                                                                                <asp:ListItem>Category</asp:ListItem>  
                                                                                <asp:ListItem>Terms</asp:ListItem>  
                                                                                <asp:ListItem>Enrollment</asp:ListItem>  
                                                                                <asp:ListItem>Grades</asp:ListItem>  
                                                                                <asp:ListItem>Attendence</asp:ListItem>  
                                                                            </asp:CheckBoxList>
                                                             </div>   
                                                    </telerik:LayoutColumn> 
                                                </Columns>
                                            </telerik:LayoutRow>
                                        </Rows>
                                       <Rows>
                                            <telerik:LayoutRow ID="LayoutRow4"    runat="server"   style="margin-top:4px;margin-left:2px;margin-right:2px">
                                                <Columns>
                                                    <telerik:LayoutColumn   Span="2"  SpanXs="2" SpanSm="2" >
                                                            <b>Repeat</b>
                                                    </telerik:LayoutColumn>
                                                     <telerik:LayoutColumn   Span="10"  SpanXs="10" SpanSm="10" >
                                                            <telerik:RadDropDownList RenderMode="Lightweight" ID="RadDropDownList1" runat="server" DefaultMessage="Select.." DropDownHeight="110px" >
                                                                <Items> 
                                                                    <telerik:DropDownListItem Text="Daily" />
                                                                    <telerik:DropDownListItem Text="Weekly" />
                                                                    <telerik:DropDownListItem Text="Monthly" />
                                                                    <telerik:DropDownListItem Text="Yearly" />
                                                                </Items>
                                                            </telerik:RadDropDownList>
                                                    </telerik:LayoutColumn> 
                                                </Columns>
                                            </telerik:LayoutRow>
                                        </Rows>
                                       <Rows>
                                            <telerik:LayoutRow ID="LayoutRow6"    runat="server"   style="margin-top:4px;margin-left:2px;margin-right:2px">
                                                <Columns>
                                                    <telerik:LayoutColumn   Span="2"  SpanXs="2" SpanSm="2" >
                                                         <b>Description</b>
                                                    </telerik:LayoutColumn>
                                                     <telerik:LayoutColumn   Span="10"  SpanXs="10" SpanSm="10" >
                                                        <telerik:RadTextBox runat="server" ID="REditorSMS"  Height="100px" Width="100%"
                                                        MaxLength ="139"  TextMode="MultiLine" >
                                                        </telerik:RadTextBox>
                                                    </telerik:LayoutColumn> 
                                                </Columns>
                                            </telerik:LayoutRow>
                                        </Rows>
                                         <Rows>
                                                <telerik:LayoutRow style="margin-top:4px;margin-left:2px;margin-right:2px;margin-bottom:4px">
                                                    <Columns>
                                                         <telerik:LayoutColumn   Span="2"  SpanXs="2" SpanSm="2" >
                                                         </telerik:LayoutColumn>
                                                         <telerik:LayoutColumn   Span="4"  SpanXs="4"  SpanMd="4"  SpanSm="4" >
                                                              <telerik:RadButton ID="RPbtnSave"   Width="100%"   ValidationGroup="VGSMSConfig" runat="server" Text="Save">
                                                                 <Icon PrimaryIconCssClass="rbSave"></Icon>
                                                              </telerik:RadButton>
                                                         </telerik:LayoutColumn> 
                                                         <telerik:LayoutColumn   Span="2"  SpanXs="2" SpanSm="2" >
                                                         </telerik:LayoutColumn>
                                                         <telerik:LayoutColumn   Span="4"  SpanXs="4"  SpanMd="4"  SpanSm="4" >
                                                            <telerik:RadButton ID="RPbtnCancel"   Width="100%"   runat="server"    Text="Cancel">
                                                                 <Icon PrimaryIconCssClass="rbCancel"></Icon>
                                                             </telerik:RadButton>
                                                        </telerik:LayoutColumn> 
                                                  </Columns>
                                                </telerik:LayoutRow>
                                           </Rows>
                                   </telerik:RadPageLayout>
                             
                        </telerik:LayoutColumn>
                             <telerik:LayoutColumn   Span="6"   SpanXs="12"  SpanMd="6"  SpanSm="6">
                               <div >
                                <telerik:RadGrid ID="RgvSMSConfig" runat="server" AutoGenerateColumns="False" Width="100%" RenderMode="Auto" 
                                FilterMenu-RenderMode="Lightweight"
                                GroupPanelPosition="Top" IsExporting="False" PageSize="8" Font-Size="10"
                                AllowFilteringByColumn="false" AllowPaging="True" AllowSorting="True"  OnNeedDataSource="RgvSMSConfig_NeedDataSource"
                                OnItemCommand="RgvSMSConfig_ItemCommand" OnSortCommand="RgvSMSConfig_SortCommand">
                                <ItemStyle Wrap="true"></ItemStyle>
                                <MasterTableView AllowMultiColumnSorting="true">
                                    <Columns>
                                       <telerik:GridTemplateColumn HeaderText="Schedule Title"  ShowSortIcon="true" SortExpression="Scheduletitle" AllowSorting="true"
                                            ItemStyle-VerticalAlign="Top"
                                            DataField="Scheduletitle"  AllowFiltering="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbCampusName" runat="server" Text='<%# Convert.ToString(Eval("Scheduletitle")) %>' />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Repeat"   AllowSorting="true" SortExpression="Repeat" 
                                             DataField="Repeat"  AllowFiltering="false">
                                            <ItemTemplate>
                                                <asp:Label ID="DeptMainName" runat="server" Text='<%# Convert.ToString(Eval("Repeat")) %>' />                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Edit" AllowFiltering="false">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnedit" runat="server" AlternateText="Edit" ToolTip="Edit" Height="16px" Width="16px"
                                                    ImageUrl="~/images/pencil_edit_button.png"  CommandName="imgbtnedit"  />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Delete" AllowFiltering="false">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtndelete" runat="server" AlternateText="Delete" ToolTip="Delete" Height="16px" Width="16px"
                                                    OnClientClick="javascript:return confirm('Are You Sure Delete This schedule?')"
                                                    ImageUrl="~/images/Delete.png" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                       </Columns>
                                </MasterTableView> 
                                <PagerStyle AlwaysVisible="true" Mode="NumericPages"></PagerStyle>
                                <FilterMenu RenderMode="Lightweight"></FilterMenu>
                                <HeaderContextMenu RenderMode="Lightweight"></HeaderContextMenu>
                                      </telerik:RadGrid>

                           </div>
                         </telerik:LayoutColumn>
                          
                      </Columns>
                        
                    </telerik:LayoutRow>
               </Rows>
       </telerik:RadPageLayout>

       
    </asp:Panel>
</asp:Content>

