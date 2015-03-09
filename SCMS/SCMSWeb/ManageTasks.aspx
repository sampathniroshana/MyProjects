<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ManageTasks.aspx.cs" Inherits="SCMSWeb.ManageTasks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
  <div class="col-md-6">
  <div class="panel">
    <div class="panel-heading">
        <h4>Task Inbox</h4> </div>
    <div class="panel-body">
    <!--  <form class="form-horizontal" role="form" > -->


  <div class="form-group">
    <label for="inputEmail3" class="col-sm-3 control-label">Email ID</label>
      
    <div class="col-sm-9">
        <p class="help-block">
          <asp:TextBox ID="TxtMainCatID0" runat="server" CssClass="form-control" Enabled="False" Width="250px"></asp:TextBox>
            </p>

    
      
    </div>
     
  </div>


  <div class="form-group">
    <label for="inputEmail3" class="col-sm-3 control-label">Phone Number</label>

    <div class="col-sm-9">
        <p class="help-block">
          <asp:TextBox ID="TxtMainCatID1" runat="server" CssClass="form-control" Enabled="False" Width="250px"></asp:TextBox>
        </p>

     
      
    </div>
     
  </div>


  <div class="form-group">
    <label for="inputEmail3" class="col-sm-3 control-label">Interaction type</label>
    <div class="col-sm-9">
        <p class="help-block">
        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control left" Width="250px" AutoPostBack="True" >
            <asp:ListItem Value="1">Activity</asp:ListItem>
            <asp:ListItem Value="2">Complain</asp:ListItem>
            <asp:ListItem Value="3">Inquery</asp:ListItem>
        </asp:DropDownList>
        </p>
    </div>
     
  </div>


  <div class="form-group">
    <label for="inputPassword3" class="col-sm-3 control-label">Main category</label>
    <div class="col-sm-9">
      <p class="help-block">
        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control left" Width="250px" AutoPostBack="True" >
            <asp:ListItem Value="1">Activity</asp:ListItem>
            <asp:ListItem Value="2">Complain</asp:ListItem>
            <asp:ListItem Value="3">Inquery</asp:ListItem>
        </asp:DropDownList>

     
      
        </p>
    </div>
  </div>

   <div class="form-group">
    <label for="inputPassword3" class="col-sm-3 control-label">Category</label>
    <div class="col-sm-9">
        <p class="help-block">
        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control left" Width="250px" AutoPostBack="True" >
            <asp:ListItem Value="1">Activity</asp:ListItem>
            <asp:ListItem Value="2">Complain</asp:ListItem>
            <asp:ListItem Value="3">Inquery</asp:ListItem>
        </asp:DropDownList>

     </p>
      
    </div>
  </div>

          <div class="form-group">
    <label for="inputPassword3" class="col-sm-3 control-label">Sub Category</label>
    <div class="col-sm-9">
      <p class="help-block">
        <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control left" Width="250px" AutoPostBack="True" >
            <asp:ListItem Value="1">Activity</asp:ListItem>
            <asp:ListItem Value="2">Complain</asp:ListItem>
            <asp:ListItem Value="3">Inquery</asp:ListItem>
        </asp:DropDownList>

     
      
        </p>
    </div>

              <asp:GridView ID="DgvMainCat" runat="server" CssClass="form-control"  AllowPaging="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
            <Columns>
                <asp:BoundField DataField="InteractionType" HeaderText="dd" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
           
        </asp:GridView>
  </div>
  <div class="form-group">
    <div class="col-sm-offset-3 col-sm-9">
      
      <p class="help-block">
        <asp:Button ID="bntSave" runat="server" Text="View Intraction" CssClass="bottom-right" Width="108px"  />
        </p>
    </div>
  </div>

 <div class="form-group">
    <label for="inputPassword3" class="col-sm-3 control-label"></label>
    <div class="col-sm-9">
        <asp:Label ID="LblMessage" runat="server" BackColor="#FFFF99" ForeColor="Red" Text="Err"></asp:Label>
      <p class="help-block"></p>
    </div>
  </div>

           <div class="form-group">
    <label for="inputPassword3" class="col-sm-3 control-label"></label>
    <div class="col-sm-9">
      <p class="help-block"></p>
    </div>
  </div>


  

 
<!--</form> -->


    </div>
  </div>
</div>
  </div>
</asp:Content>
