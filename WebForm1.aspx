<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Employee_Data.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Data</title>
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>--%>
     <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <script>
        
        function Check() {
            var err = document.getElementById("error");
            var inpt = document.getElementById("filter").value;
            var pattern = /^[A-Za-z]+$/;
            var err = document.getElementById("error");
            err.innerHTML = "";
            if (!inpt.match(pattern)) {
                var err = document.getElementById("error");             
                err.innerHTML = "Enter a valid expression!";
                
            }
            else {
                var inpt = document.getElementById("filter").value;
                $.ajax({
                    url: 'WebForm1.aspx/DisplayOptions',
                    type: 'post',
                    data: JSON.stringify({ "userInput": inpt }),
                    contentType: 'application/json',
                    async: false,
                    success: function (data) {
                        var listOptions = document.getElementById("opt");
                        let rand = "";
                        for (let i = 0; i < (data.d).length; i++) {
                            rand += '<option value="' + data.d[i] + '"></option>';
                        }
                        listOptions.innerHTML = '<datalist id="filter">' + rand + '</datalist>';
                    }
                });
                 
            }
        }
        
            
    </script>
    <style>
        #filter {
           
            padding:3px;
            border:solid;
            font-size:large;
            width: 300px;
            background-color:#caf0f8 ;
            font-family:Helvetica;
            margin-bottom: 3px;
        }
        #filterBtn {
         
            padding:3px;
            border:solid;
            font-size:large;
            padding-left:5px;
            padding-right:5px;
            border-radius:3px;
            font-family:Helvetica;
            margin-bottom: 10px;
        
        }
        .clear {
            clear:both;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <asp:TextBox runat="server" ID="filter" placeholder="Filter by Department" OnKeyUp=" Check()"></asp:TextBox><br />
            <div id="opt">

            </div>
            <asp:Label runat="server" id="error" style="color:red"></asp:Label>
        </div>
        <div>
            <asp:Button ID="filterBtn" runat="server" Text="Filter" OnClick="filterBtn_Click"/>
        </div>
        <div class="clear"></div>
        <div>
            <asp:gridview id="EmployeeGridView"  
        autogeneratecolumns="false" cellpadding="3" font-names="Helvetica" font-size="Larger"  gridlines="Both" 
        runat="server" BackColor="#219ebc">  
                <AlternatingRowStyle BackColor="#caf0f8" /> 
                <HeaderStyle BackColor="#23047" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <columns>
          <asp:boundfield datafield="id"
            headertext="Employee ID" />
          <asp:boundfield datafield="name"
            headertext="Employee Name"/>
          <asp:boundfield datafield="email"
            headertext="Email"/>
          <asp:boundfield datafield="dept"
            headertext="Department"/>
          <asp:boundfield datafield="contact"
            headertext="Phone Number"/>
            <asp:commandfield ShowDeleteButton="true" ShowEditButton="True"
            headertext="Edit Controls"/>
        
        </columns>
        
      </asp:gridview>
        </div>
    </form>
</body>
</html>
