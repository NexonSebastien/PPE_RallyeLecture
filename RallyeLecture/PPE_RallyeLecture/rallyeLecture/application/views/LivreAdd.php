<?php echo validation_errors(); ?>
<?php echo form_open_multipart('Livre/Add'); ?>
<div>Titre      : <input type="text" name="titre" value="<?php echo $this->input->post('titre'); ?>" /></div>
<!--<div>Couverture : <input type="text" name="couverture" value="<?php //echo $this->input->post('couverture'); ?>" /></div> -->
<div id="div1"> Couverture : <input type="file" name="couverture"  onchange="loadFile(event);" /></div>

<!--<div><img src="<?php //echo base_url('img/'.$this->input->post('couverture')) ?>" alt="<?php //echo $this->input->post('titre'); ?>" height="100" width="100"> </div>-->
<div>Auteur     : <?php $comboBoxAuteur->Render(); ?></div>
<div>Editeur    : <?php $comboBoxEditeur->Render(); ?></div>
<div>Quizz      : <?php $comboBoxQuizz->Render(); ?></div>
<img id="output"height="100" width="100"/>
</br>
<button type="submit">Sauvegarder</button>
<?php echo form_close(); ?>
<script>
  var loadFile = function(event) {
    var output = document.getElementById('output');
    output.src = URL.createObjectURL(event.target.files[0]);
  };
</script>