<?php require_once("adminchk.php");  ?>
<!DOCTYPE html>
<!-- First HTML5 example. -->
<html>
	<head>
		<meta charset = "utf-8">
		<title>Database Test</title>
		<link href="style.css" rel="stylesheet" type="text/css">
	</head>
	<body>
<?php

include("db.php");

$db = new sb_mysqli();


/* Select queries return a resultset */
if ($result = $db->query("
	SELECT students.studentid,fname,lname,gpa FROM students
	INNER JOIN gpa ON students.studentid = gpa.studentid
	")) {
	if ( $result->num_rows > 0 ) {
		?>
		<div id="content">
		<div id="logout"><a href="logout.php">Log Out</a></div>
		<div id="swag">
		<table>
			<thead>
				<th>Name</th>
				<th>GPA</th>
				<td>[<a href="/dbadd.php">add</a>]</th>

			</thead>
			<tbody>
		<?php
		while($row = $result->fetch_assoc()) {
    			printf("<tr><td>%s %s</td><td>%.2f</td><td>[<a href=\"/dbedit.php?sid=%d\">edit</a>]<td><td>[<a href=\"/dbdelete.php?sid=%d\">delete</a>]<td></tr>"
				,$row['fname'],$row['lname'],$row['gpa'],$row['studentid'],$row['studentid']);
	
		}
		?>
			</tbody>
		</table>
		</div> <!-- end swag-->
		
		<?php
	}
	/* free result set */
	mysqli_free_result($result);
}
 
$db->close();

?> 
<?php


$db = new sb_mysqli();
//Start your session


/* Select queries return a resultset */
$result = $db->query("
	SELECT DISTINCT fname, coursename
	FROM studentCourses
	INNER JOIN courses ON courses.courseid = studentCourses.courseid
	INNER JOIN students ON students.studentid = studentCourses.studentid
	ORDER BY fname ASC
	") ;
	if ( $result->num_rows >= 0 ) {
		?>
		<table>
			<thead>
				<th>Student Name<th>
				<th>Courses</th>
					
			</thead>
			<tbody>
		<?php
		while($row = $result->fetch_assoc()) {
    			printf("<tr> <td>%s</td><td>%s</td></tr>"
				,$row['fname'],$row['coursename']);
				
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
