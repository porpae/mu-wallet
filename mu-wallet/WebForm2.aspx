<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="mu_wallet.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
  <style>
    /* Set height of the grid so .sidenav can be 100% (adjust as needed) */
    .row.content {height: 550px}
    
    /* Set gray background color and 100% height */
    .sidenav {
      background-color: #f1f1f1;
      height: 100%;
    }
        
    /* On small screens, set height to 'auto' for the grid */
    @media screen and (max-width: 767px) {
      .row.content {height: auto;} 
    }
  </style>

</head>
<body>
<nav class="navbar navbar-inverse visible-xs">
  <div class="container-fluid">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>                        
      </button>
      <a class="navbar-brand" href="#">MU Wallet</a>
    </div>
    <div class="collapse navbar-collapse" id="myNavbar">
      <ul class="nav navbar-nav">
        <li><a href="#">เช็คยอดเงิน</a></li>
        <li class="active"><a href="#">โอนเงิน</a></li>
      </ul>
    </div>
  </div>
</nav>

<div class="container-fluid">
  <div class="row content">
    <div class="col-sm-3 sidenav hidden-xs">
      <h2>ธนาคารรวมกันเราเจ๊ง</h2>
      <ul class="nav nav-pills nav-stacked">
        <li class="active"><a href="#section1">โอนเงิน</a></li>
        <li><a href="#section2">เช็คยอดเงิน</a></li>
      </ul><br>
    </div>
    <br>
    
    <div class="col-sm-9">
      <div class="well">
        <h4>โอนเงิน</h4><br />
        <tr align="center">
            <td>โอนเงินสำเร็จ</td></tr>
        <form >

          <table width="400">
            <tr height="10">
                
              <td>บัญชีผู้โอน</td> 
              <td><label for="account_transfer"> 123-456-789 (Akanit)</td>
            </tr>
            <tr>
              <td>บัญชีผู้รับโอน</td>
              <td><label for="account_receive"> 234-567-123 (Somboon)</td>
            </tr>
            <tr>
              <td>จำนวนเงินที่โอน</td>
              <td><label for="amount_transfer"> 1,000 บาท</td>
            </tr>
          </table>
          
        <!--<input type="submit" value="Submit">
          <input type="submit" value="Submit_ok"-->
          <div align="center">
          <button type="button" onclick="alert('กลับสู่เมนูหลัก')">ตกลง</button>
        </div>
        </form>
        
      </div>
    </div>

  </div>
</div>

</body>
</html>
