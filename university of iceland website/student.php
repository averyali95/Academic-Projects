
<!DOCTYPE html>
<html>
<head>
<title>Your Home Page</title>
<link href="style.css" rel="stylesheet" type="text/css">
</head>
<body>
<div id="content">

<?php

include("db.php");

$db = new sb_mysqli();
//Start your session
session_start();
   //Read your session (if it is set)
   if (isset($_SESSION['userid']))
      echo "Username: ".$_SESSION['userid'];


/* Select queries return a resultset */
$result = $db->query("
	SELECT students.studentid,fname,lname,gpa,street,city,state,zip FROM students
	INNER JOIN gpa ON students.studentid = gpa.studentid
	INNER JOIN adress ON students.studentid = adress.studentid
	WHERE students.studentid = '".$_SESSION['usernum']."'
	") ;
	if ( $result->num_rows >= 0 ) {
		?>
		<div id="logout"><a href="logout.php">Log Out</a></div>
		<table>
			<thead>
				<th>Name</th>
				<th>GPA</th>
				<th>Street</th>
				<th>City</th>
				<th>State<th>
				<th>Zip Code</th>
				
			</thead>
			<tbody>
		<?php
		while($row = $result->fetch_assoc()) {
    			printf("<tr><td>%s %s</td><td>%.2f</td><td>%s</td><td> %s </td> <td> %s </td><td> %s </td> <td>%s</td></tr>"
				,$row['fname'],$row['lname'],$row['gpa'],$row['street'],$row['city'],$row['state'],"    ",$row['zip']);
				
		}
		?>
			</tbody>
		</table>
		<br><br>
		
		
		<?php
	}
	/* free result set */
	mysqli_free_result($result);

$db->close();

?>
<?php


$db = new sb_mysqli();
//Start your session


/* Select queries return a resultset */
$result = $db->query("
	SELECT coursename
	FROM studentCourses
	INNER JOIN courses ON courses.courseid = studentCourses.courseid
	INNER JOIN students ON students.studentid = studentCourses.studentid
	WHERE students.studentid = '".$_SESSION['usernum']."'
	") ;
	if ( $result->num_rows >= 0 ) {
		?>
		<table>
			<thead>
				
				<th>Courses</th>
					
			</thead>
			<tbody>
		<?php
		while($row = $result->fetch_assoc()) {
    			printf("<tr> <td>%s</td></tr>"
				,$row['coursename']);
				
		}
		?>
			</tbody>
		</table>
		
		
		<?php
	}
	/* free result set */
	mysqli_free_result($result);

$db->close();

?>
</div>
</body>
</html>