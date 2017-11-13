<?php require_once("adminchk.php");  ?>

<?php

include("db.php");
if (isset($_GET['sid'])) {
$del = $_GET['sid'];

	$db = new sb_mysqli();


	if ($db->query("DELETE FROM students
					WHERE students.studentid = $del")) 
	
			{
			echo "Deleted";
			?>
			<script>	
				window.location = '/dbview.php';
			</script>
			<?php
		}
	
	else {
		echo "Student delete failed." ;
		?>
			<script>	
				window.location = '/dbview.php';
			</script>
			<?php
	}
	
	$db->close();

 }

?> 
