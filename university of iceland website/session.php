<?php
include("db.php");
// Establishing Connection with Server by passing server_name, user_id and password as a parameter
$connection = mysql_connect("localhost", "root", "");
// Selecting Database
$db  = new sb_mysqli();
session_start();// Starting Session
// Storing Session
$user_check=$_SESSION['userid'];
// SQL Query To Fetch Complete Information Of User
$ses_sql=mysql_query("select userid from users where userid='$user_check'", $connection);
$row = mysql_fetch_assoc($ses_sql);
$login_session =$row['userid'];
if(!isset($login_session)){
mysql_close($connection); // Closing Connection
header('Location: login.php'); // Redirecting To Home Page
}
?>