<%@ Page Title="" Language="C#" MasterPageFile="~/DSISLMS_Main.Master" AutoEventWireup="true" CodeBehind="frmblackboard.aspx.cs" Inherits="DSISLMS_Web.frmblackboard1"  Async="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="CPhead" ContentPlaceHolderID="CPhead" runat="server">
    <style type="text/css">

        .ModalPopupBG
        {
            background-color: Black;filter: alpha(opacity=90);opacity: 0.8;
        }
    </style>
</asp:Content>
<asp:Content ID="CPHDetail" ContentPlaceHolderID="CPHDetail" runat="server">
    <telerik:RadAjaxLoadingPanel ID="RALPfrmblackboard" runat="server" Height="75px"
        Width="75px" Transparency="50">
    </telerik:RadAjaxLoadingPanel>
      <telerik:RadAjaxManagerProxy ID="RAMfrmblackboard" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Pfrmblackboard">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Pfrmblackboard" LoadingPanelID="RALPfrmblackboard"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    
   <asp:Panel runat="server" ID="Pfrmblackboard">
           <telerik:RadPageLayout runat="server" ID="RDPLayoutfrmemailconfiguration" GridType="Fluid">
              <Rows  >
                 <telerik:LayoutRow ID="LRTab"  style="margin-top:4px;margin-left:2px;margin-right:2px;margin-bottom:4px"  runat="server"  >
                        <Columns>
                             <telerik:LayoutColumn   Span="12"   SpanXs="12"  SpanMd="12"  SpanSm="12">
                                  <telerik:RadTabStrip RenderMode="Classic" AutoPostBack="true" OnTabClick="RTSMainblackboardTab_TabClick" runat="server" ID="RTSMainblackboardTab"   MultiPageID="RMPBlackboard" SelectedIndex="0" >
                                    <Tabs>
                                        <telerik:RadTab Text="Users"  TabIndex="0"></telerik:RadTab>
                                        <telerik:RadTab Text="Terms" TabIndex="1" ></telerik:RadTab>
                                        <telerik:RadTab Text="Courses" TabIndex="2" ></telerik:RadTab>
                                        <telerik:RadTab Text="Enrollment" TabIndex="3"></telerik:RadTab>
                                   </Tabs>
                                </telerik:RadTabStrip>                        
                             </telerik:LayoutColumn>
                        </Columns>
                   </telerik:LayoutRow >
                  <telerik:LayoutRow    style="margin-top:4px;margin-left:2px;margin-right:2px;margin-bottom:4px" runat="server"  >
                        <Columns>
                             <telerik:LayoutColumn   Span="12"   SpanXs="12"  SpanMd="12"  SpanSm="12">
                                   <div style="border: 1px solid #e9e4e4;padding:10px;height:inherit;">
                                      
                                       <telerik:RadLabel ID="RLresult" Font-Bold="true" Font-Size="14px" runat="server"></telerik:RadLabel>
                                       <telerik:RadMultiPage runat="server" ID="RMPBlackboard"  SelectedIndex="0"
                                                    CssClass="multiPage" Width="100%">
                                                    <telerik:RadPageView runat="server" ID="RPVuser">
                                                       
                                                       <!--Start User Grid Bind  -->
                                                         <telerik:RadGrid ID="RgvUsers" runat="server" AutoGenerateColumns="False" Width="100%"  
                                                            FilterMenu-RenderMode="Lightweight"
                                                            OnSortCommand="RgvUsers_SortCommand"  GroupPanelPosition="Top" PageSize="8" Font-Size="10"
                                                            OnItemCommand="RgvUsers_ItemCommand" OnNeedDataSource="RgvUsers_NeedDataSource" OnItemDataBound="RgvUsers_ItemDataBound"
                                                            AllowPaging="True" AllowSorting="True" AllowFilteringByColumn="true">
                                                                <ItemStyle Wrap="true"></ItemStyle>
                                                                <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                                                                <MasterTableView  AllowMultiColumnSorting="true">
                                                                    <Columns>
                                                                        <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" Visible="false" HeaderStyle-Width="100%" ItemStyle-Width="100%" AllowFiltering="false">
                                                                              <ItemTemplate>
                                                                                <asp:CheckBox ID="ItemChkbox" runat="server"  
                                                                                  AutoPostBack="True" />
                                                                              </ItemTemplate>
                                                                              <HeaderTemplate>
                                                                                <asp:CheckBox ID="headerChkbox" runat="server" OnCheckedChanged="CHBToggleUserAll"
                                                                                  AutoPostBack="True" />
                                                                              </HeaderTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Student No"  ShowSortIcon="true" Visible="true" AllowSorting="true" ItemStyle-VerticalAlign="Top"
                                                                             DataField="StudentNo" AllowFiltering="true" HeaderStyle-Width="100%" ItemStyle-Width="100%" >
                                                                             <ItemTemplate>
                                                                                <asp:Label ID="lbStudentNo" runat="server" Visible="true" Text='<%# Convert.ToString(Eval("StudentNo")) %>' />
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="User Name"  ShowSortIcon="true"  AllowSorting="true" ItemStyle-VerticalAlign="Top" DataField="Username"  
                                                                             AllowFiltering="true" Visible="true" HeaderStyle-Width="100%" ItemStyle-Width="100%" >
                                                                            <ItemTemplate> 
                                                                                <asp:Label ID="lbUsername" runat="server" Visible="true" Text='<%# Convert.ToString(Eval("login_id")) %>' />
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Last Name"  ShowSortIcon="true"  AllowSorting="true" ItemStyle-VerticalAlign="Top" 
                                                                            DataField="last_name" Visible="true"   AllowFiltering="true" HeaderStyle-Width="100%" ItemStyle-Width="100%" >
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblast_name" runat="server" Visible="true" Text='<%# Convert.ToString(Eval("last_name")) %>' />
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="First Name"  ShowSortIcon="true" Visible="true"   AllowSorting="true" ItemStyle-VerticalAlign="Top" DataField="first_name"  
                                                                             AllowFiltering="true" HeaderStyle-Width="100%" ItemStyle-Width="100%" >
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbfirst_name" runat="server" Visible="true" Text='<%# Convert.ToString(Eval("first_name")) %>' />
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn   ShowSortIcon="true" Visible="false"   AllowSorting="true" ItemStyle-VerticalAlign="Top" DataField="first_name"  
                                                                             AllowFiltering="true" HeaderStyle-Width="100%" ItemStyle-Width="100%" >
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbOperation" runat="server" Visible="true" Text='<%# Convert.ToString(Eval("Operation")) %>' />
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn    ItemStyle-VerticalAlign="Top" HeaderStyle-Width="100%" ItemStyle-Width="100%"  HeaderStyle-CssClass="rigthcol" ItemStyle-CssClass="rigthcol" AllowSorting="false"
                                                                            AllowFiltering="false">
                                                                            <ItemTemplate>
                                                                                <telerik:RadPushButton runat="server"  id="btnpushmodel" Width="100%" Text="Send to Blackboard"  CommandName="btnpushmodel"    Primary="true"   >
                                                                                    <Icon CssClass="rbNext"></Icon>
                                                                                 </telerik:RadPushButton>
                                                                            </ItemTemplate>
                                                                        
                                                                        </telerik:GridTemplateColumn>                                                                    
                                                                    </Columns>
                                                                    <PagerStyle AlwaysVisible="false"></PagerStyle>
                                                                </MasterTableView>
                                                                <PagerStyle AlwaysVisible="true" Mode="NumericPages"></PagerStyle>
                                                                <FilterMenu RenderMode="Lightweight"></FilterMenu>
                                                                <HeaderContextMenu RenderMode="Lightweight"></HeaderContextMenu>
                                                                    <ClientSettings>
                                                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="true"  ></Scrolling>
                                                                </ClientSettings>  
                                                            </telerik:RadGrid>
                                                         <!--End User Grid Bind -->
                                                    </telerik:RadPageView>
                                                    <telerik:RadPageView runat="server" ID="RPVTerm">
                                        
                                                         <!--Start Terms Grid Bind  -->
                                                         <telerik:RadGrid ID="RgvTerms" runat="server" AutoGenerateColumns="False" Width="100%"  
                                                            FilterMenu-RenderMode="Lightweight"
                                                            OnSortCommand="RgvTerms_SortCommand"  GroupPanelPosition="Top" PageSize="8" Font-Size="10"
                                                            OnItemCommand="RgvTerms_ItemCommand" OnItemDataBound="RgvTerms_ItemDataBound" OnNeedDataSource="RgvTerms_NeedDataSource"
                                                            AllowPaging="True" AllowSorting="True" AllowFilteringByColumn="true">
                                                                <ItemStyle Wrap="true"></ItemStyle>
                                                                <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                                                                <MasterTableView  AllowMultiColumnSorting="true">
                                                                    <Columns>
                                                                        
                                                                        <telerik:GridTemplateColumn HeaderText="Term ID"  ShowSortIcon="true" Visible="true" AllowSorting="true"
                                                                             ItemStyle-VerticalAlign="Top" DataField="TermID" AllowFiltering="true" HeaderStyle-Width="100%" ItemStyle-Width="100%" >
                                                                             <ItemTemplate>
                                                                                <asp:Label ID="lbTermID" runat="server" Visible="true" Text='<%# Convert.ToString(Eval("TermID")) %>' />
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Term Name"  ShowSortIcon="true"  AllowSorting="true" ItemStyle-VerticalAlign="Top" DataField="name"  
                                                                             AllowFiltering="true" Visible="true" HeaderStyle-Width="100%" ItemStyle-Width="100%" >
                                                                            <ItemTemplate> 
                                                                                <asp:Label ID="lbtermname" runat="server" Visible="true" Text='<%# Convert.ToString(Eval("name")) %>' />
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        
                                                                        <telerik:GridTemplateColumn HeaderText="Start Date"  ShowSortIcon="true"  AllowSorting="true" ItemStyle-VerticalAlign="Top" 
                                                                            DataField="last_name" Visible="true"   AllowFiltering="true" HeaderStyle-Width="100%" ItemStyle-Width="100%" >
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbstart_date" runat="server" Visible="true" Text='<%# Convert.ToString(Eval("start_date")) %>' />
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="End Date"  ShowSortIcon="true" Visible="true"   AllowSorting="true" ItemStyle-VerticalAlign="Top" 
                                                                            DataField="end_date"  
                                                                             AllowFiltering="true" HeaderStyle-Width="100%" ItemStyle-Width="100%" >
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbend_date" runat="server" Visible="true" Text='<%# Convert.ToString(Eval("end_date")) %>' />
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn   ShowSortIcon="true" Visible="false"   AllowSorting="true" ItemStyle-VerticalAlign="Top" DataField="first_name"  
                                                                             AllowFiltering="true" HeaderStyle-Width="100%" ItemStyle-Width="100%" >
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbOperation" runat="server" Visible="true" Text='<%# Convert.ToString(Eval("Operation")) %>' />
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn    ItemStyle-VerticalAlign="Top" HeaderStyle-Width="100%" ItemStyle-Width="100%"  HeaderStyle-CssClass="rigthcol" ItemStyle-CssClass="rigthcol" AllowSorting="false"
                                                                            AllowFiltering="false">
                                                                            <ItemTemplate>
                                                                                <telerik:RadPushButton runat="server" ID="btnpushmodel"  Width="100%" Text="Send to Blackboard"  CommandName="btnpushmodel"    Primary="true"   >
                                                                                    <Icon CssClass="rbNext"></Icon>
                                                                                    </telerik:RadPushButton>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>                                                                    
                                                                    </Columns>
                                                                    <PagerStyle AlwaysVisible="false"></PagerStyle>
                                                                </MasterTableView>
                                                                <PagerStyle AlwaysVisible="true" Mode="NumericPages"></PagerStyle>
                                                                <FilterMenu RenderMode="Lightweight"></FilterMenu>
                                                                <HeaderContextMenu RenderMode="Lightweight"></HeaderContextMenu>
                                                                    <ClientSettings>
                                                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="true"  ></Scrolling>
                                                                </ClientSettings>  
                                                            </telerik:RadGrid>
                                                         <!--End Terms Grid Bind -->

                                                    </telerik:RadPageView>
                                                    <telerik:RadPageView runat="server" ID="RPVCoures">
                                                        <!--Start Courses Grid Bind  -->
                                                         <telerik:RadGrid ID="RgvCourse" runat="server" AutoGenerateColumns="False" Width="100%"  
                                                            FilterMenu-RenderMode="Lightweight"
                                                            OnSortCommand="RgvCourse_SortCommand"  GroupPanelPosition="Top" PageSize="8" Font-Size="10"
                                                            OnItemCommand="RgvCourse_ItemCommand" OnItemDataBound="RgvCourse_ItemDataBound" OnNeedDataSource="RgvCourse_NeedDataSource"
                                                            AllowPaging="True" AllowSorting="True" AllowFilteringByColumn="true">
                                                                <ItemStyle Wrap="true"></ItemStyle>
                                                                <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                                                                <MasterTableView  AllowMultiColumnSorting="true">
                                                                    <Columns>
                                                                       <telerik:GridTemplateColumn HeaderText="Course Offering No"  ShowSortIcon="true" Visible="true" AllowSorting="true"
                                                                             ItemStyle-VerticalAlign="Top" DataField="TermID" AllowFiltering="true" HeaderStyle-Width="100%" ItemStyle-Width="100%" >
                                                                             <ItemTemplate>
                                                                                <asp:Label ID="lbCourseOfferingNo" runat="server" Visible="true" Text='<%# Convert.ToString(Eval("CourseOfferingNo")) %>' />
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>


                                                                        
                                                                        
                                                                        <telerik:GridTemplateColumn HeaderText="Short Name"  ShowSortIcon="true"  AllowSorting="true" ItemStyle-VerticalAlign="Top" DataField="name"  
                                                                             AllowFiltering="true" Visible="true" HeaderStyle-Width="100%" ItemStyle-Width="100%" >
                                                                            <ItemTemplate> 
                                                                                <asp:Label ID="lbshort_name" runat="server" Visible="true" Text='<%# Convert.ToString(Eval("short_name")) %>' />
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        
                                                                        <telerik:GridTemplateColumn HeaderText="Long Name"  ShowSortIcon="true"  AllowSorting="true" ItemStyle-VerticalAlign="Top" 
                                                                            DataField="long_name" Visible="true"   AllowFiltering="true" HeaderStyle-Width="100%" ItemStyle-Width="100%" >
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblong_name" runat="server" Visible="true" Text='<%# Convert.ToString(Eval("long_name")) %>' />
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Term Id"  ShowSortIcon="true" Visible="true"   AllowSorting="true" ItemStyle-VerticalAlign="Top" 
                                                                            DataField="term_id"  
                                                                             AllowFiltering="true" HeaderStyle-Width="100%" ItemStyle-Width="100%" >
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbtermid" runat="server" Visible="true" Text='<%# Convert.ToString(Eval("term_id")) %>' />
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="BB Term Id"  ShowSortIcon="true" Visible="true"   AllowSorting="true" ItemStyle-VerticalAlign="Top" 
                                                                            DataField="Termid"  
                                                                             AllowFiltering="true" HeaderStyle-Width="100%" ItemStyle-Width="100%" >
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbterm_id" runat="server" Visible="true" Text='<%# Convert.ToString(Eval("Termid")) %>' />
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn   ShowSortIcon="true" Visible="false"   AllowSorting="true" ItemStyle-VerticalAlign="Top" DataField="first_name"  
                                                                             AllowFiltering="true" HeaderStyle-Width="100%" ItemStyle-Width="100%" >
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbOperation" runat="server" Visible="true" Text='<%# Convert.ToString(Eval("Operation")) %>' />
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn    ItemStyle-VerticalAlign="Top" HeaderStyle-Width="100%" ItemStyle-Width="100%"  HeaderStyle-CssClass="rigthcol" ItemStyle-CssClass="rigthcol" AllowSorting="false"
                                                                            AllowFiltering="false">
                                                                            <ItemTemplate>
                                                                                <telerik:RadPushButton runat="server" ID="btnpushmodel"  Width="100%" Text="Send to Blackboard"  CommandName="btnpushmodel"    Primary="true"   >
                                                                                    <Icon CssClass="rbNext"></Icon>
                                                                                    </telerik:RadPushButton>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>                                                                    
                                                                    </Columns>
                                                                    <PagerStyle AlwaysVisible="false"></PagerStyle>
                                                                </MasterTableView>
                                                                <PagerStyle AlwaysVisible="true" Mode="NumericPages"></PagerStyle>
                                                                <FilterMenu RenderMode="Lightweight"></FilterMenu>
                                                                <HeaderContextMenu RenderMode="Lightweight"></HeaderContextMenu>
                                                                    <ClientSettings>
                                                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="true"  ></Scrolling>
                                                                </ClientSettings>  
                                                            </telerik:RadGrid>
                                                         <!--End Courses Grid Bind -->

                                                 
                                                    </telerik:RadPageView>
                                                    <telerik:RadPageView runat="server" ID="RPVEnrollment">
                                                         Enrollment
                                                    </telerik:RadPageView>
                                          </telerik:RadMultiPage>
                                    </div>
                             </telerik:LayoutColumn>
                        </Columns>
                     </telerik:LayoutRow >
                  </Rows>
           </telerik:RadPageLayout>
          
          

             
   </asp:Panel>
</asp:Content>
