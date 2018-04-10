<!-- navigation -->
<div class="navigation">
    <a href="<?php echo base_url(); ?>">Home</a>
    <a href="<?php echo base_url('livre/add/');?>">Ajouter</a>
</div>
<!-- Bouton recherche -->
<?php echo validation_errors();
echo form_open(base_url('Livre/recherche'));
echo form_input('titre');
echo form_submit('valider','valider');
 echo form_close();?>

<table>
    <tr>
        <td>#</td>
        <td>titre</td>
        <td>couverture</td>
        <td>Auteur</td>
        <td>id editeur</td>
        <td>id quizz</td>
        <td>image</td>
        <td>Actions</td>
    </tr>
        <?php foreach ($livres as $l): ?>
            <tr>
            <?php 
            if($l['id']%2 ==1)
            {
                
                echo'<tr style="background-color:rgb(58,31,248);color:white;">';
                
            }
            else
            {
                echo'<tr style="background-color:rgb(250,15,10);">';
            }
            ?>
            
                <td><?php echo $l['id']; ?></td>
                <td><?php echo $l['titre']; ?></td>
                <td><?php echo $l['couverture']; ?></td>
                <?php
                $donneeAuteur =  $this->livreModel->get_auteur($l['idAuteur']);
                ?>

                <td><?php echo $donneeAuteur['nom']?></td>
                <td><?php echo $l['idEditeur']; ?></td>
                <td><?php echo $l['idQuizz']; ?></td>
                <td><img src="<?php echo base_url('img/'.$l['couverture']) ?>" alt="<?php echo $l['titre']; ?>" height="50" width="50"> </td>
                <td>
                    <a href="<?php echo site_url('livre/edit/'.$l['id']); ?>">Edit</a> | 
                    <a href="<?php echo site_url('livre/remove/'.$l['id']); ?>">Delete</a>
                </td>
            </tr>
        <?php endforeach; ?>

</table>
<?php 
echo $links; 
?>
