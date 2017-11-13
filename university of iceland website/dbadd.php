<?php require_once("adminchk.php");  ?>
<!DOCTYPE html>
<!-- First HTML5 example. -->
<html>
	<head>
		<meta charset = "utf-8">
		<title>Database Test</title>
	</head>
	<body>
<?php

include("db.php");

if ( isset($_POST['fname'] ) ) {
	$db = new sb_mysqli();


	if ($db->query("INSERT INTO students (fname,lname) VALUES ('".$db->escape_string($_POST['fname'])."','".$db->escape_string($_POST['lname'])."')")) {
		if ( $db->query("INSERT INTO gpa (studentid,gpa) VALUES (".$db->insert_id.",".$db->escape_string($_POST['gpa']).")" )){
			echo "Added";
			?>
			<script>	
				window.location = '/dbview.php';
			</script>
			<?php
		}
	
	} else {
		die("Student add failed.");
	}
	
	$db->close();
} else {
	$_POST['fname'] = "";
	$_POST['lname'] = "";
	$_POST['gpa'] = "3.0";
}

?>
		<h1>Add Student</h1>
		<form method="post">
			<label>
				First name:
				<input name="fname" type="text" value="<?php echo $_POST['fname'];?>">
			</label>
			<p>
			<label>
				Last name:
				<input name="lname" type="text"  value="<?php echo $_POST['lname'];?>">
			</label>
			<p>
			<label>
				GPA:
				<input name="gpa" type="number" min="0" max="4"  value="<?php echo $_POST['gpa'];?>" step="0.01">
			</label>
			<p>
			<input type="submit" value="Add Student">
		</form>
	</body>
</html>
