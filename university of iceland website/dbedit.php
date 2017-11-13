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

 $db = new sb_mysqli();
if ( isset($_POST['sid'] ) ) {


	if ($db->query("UPDATE students SET fname='".$db->escape_string($_POST['fname'])."',lname='".$db->escape_string($_POST['lname'])."' WHERE studentid='".$db->escape_string($_POST['sid'])."'")) {
		if ( $db->query("UPDATE gpa SET gpa=".$db->escape_string($_POST['gpa'])." WHERE studentid='".$db->escape_string($_POST['sid'])."'")) {
			echo "Updated";
			?>
			<script>	
				window.location = '/dbview.php';
			</script>
			<?php
		}
	
	} else {
		die("Student add failed.");
	}
	
	//$db->close();
} 

if ( isset($_GET['sid'] ) && !(isset($_POST['fname']) && isset($_POST['lname']) && isset($_POST['gpa']) )) {

	$result = $db->query("
		SELECT students.studentid,fname,lname,gpa FROM students
		INNER JOIN gpa ON students.studentid = gpa.studentid
		WHERE students.studentid = ".$db->escape_string($_GET['sid'])."");
	
	if ( $result && $result->num_rows == 1 ) {	
		$s = $result->fetch_assoc();
		$_POST['fname'] = $s['fname'];
		$_POST['lname'] = $s['lname'];
		$_POST['gpa'] = $s['gpa'];
		$_POST['sid'] = $s['studentid'];
	} else {
		die("Does not exist");
	}
}
?>
		<h1>Edit Student</h1>
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
			<input name="sid" type="hidden" value="<?php echo $_POST['sid'];?>">
			<input type="submit" value="Update Student">
		</form>
	</body>
</html>
