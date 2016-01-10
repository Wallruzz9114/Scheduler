<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Scheduler._Default" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
     <style>
        #scheduler_here table {
            border: none;
            border-collapse: collapse;
        }
        #scheduler_here table td {
            padding: 0;
            border: none;
        }
        #scheduler_here table th {
            padding: 0;           
        }
     </style>
     <div style="height:509px; width: 100%;">
        <%= this.Scheduler.Render() %>
     </div>	
</asp:Content>
