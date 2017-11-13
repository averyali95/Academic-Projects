	  <?php

include("db.php");

function redirect($to) {
	if ( strlen($to) == 0 )
		$url = "/dbview.php";
	else
		$url = $to;
	header('Location: ' . $url, true, 302);

	exit();
}


if ( isset($_POST['from']) )
	$from = $_POST['from'];
else 
	if ( isset($_SERVER['HTTP REFERER']) )
		$from = $_SERVER['HTTP REFERER'];
	else
		$from = "";


$db = new sb_mysqli();
session_start();

$msg = "Login to access this area";

if ( isset($_SESSION['usernum']) && isset($_SESSION['userid']) && isset($_SESSION['level']) ) {
	//already logged in
	redirect($from);
} elseif ( isset($_POST['userid']) && isset($_POST['password']) && isset($_POST['from']) ) {
	$result = $db->query("
 		SELECT usernum,userid,level FROM users
       		WHERE userid='".$db->escape_string($_POST['userid'])."' AND password=password('".$db->escape_string($_POST['password'])."')");

	if ($result && $result->num_rows == 1 ) {
		$u = $result->fetch_assoc();
		$_SESSION['usernum'] = $u['usernum'];
		$_SESSION['userid'] = $u['userid'];
		$_SESSION['level'] = $u['level'];
		if($_SESSION['level'] == 1){
			redirect($_POST['from']);
		}
		elseif($_SESSION['level'] == 2) {
			redirect("student.php");
		}
	} else {
		$msg = "Incorrect userid and/or password.";
	}
}

 
?>
<!DOCTYPE html>
<!-- First HTML5 example. -->
<html>
   <head>
      <meta charset = "utf-8">
      <title>Login</title>
   </head>

   <body>
	<h3><?php echo $msg; ?></h3>
      	<form method="post">
		<label>
			Username:
			<input name="userid" type="text" value="">
		</label>
		<p>
		<label>
			Password:
			<input name="password" type="password" value="">
		</label>
		<p>
		<input name="from" type="hidden" value="<?php echo $from; ?>">
		<input type="submit" value="login">
	</form>
   </body>
</html>
