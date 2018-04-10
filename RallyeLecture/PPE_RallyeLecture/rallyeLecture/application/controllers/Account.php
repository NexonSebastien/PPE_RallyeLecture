<?php

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 * Description of Account
 *
 * @author snexon
 */
class Account extends CI_Controller{
  
    public function __construct() {
        parent::__construct();
        $this->load->model('EnseignantModel');
        $this->load->library('Aauth');
        $this->load->library('form_validation');
    }
    
    public function  verification($idAauth,$keyVerif)
    {
        $this->aauth->verify_user($idAauth,$keyVerif);
        
        $this->load->view('AppHeader');
        $this->load->view('AccountInscrit');
        $this->load->view('AppFooter');

        
    }
    
    public function create()
    {
        $this->form_validation->set_rules('password','Password','required|max_length[100]');
        $this->form_validation->set_rules('passwordConfirmation','Confirmer le mot de passe','required|max_length[100]|callback_password_check');
        if($this->form_validation->run())
        {
            $password=$this->input->post('password');
            $email=$this->input->post('email');
            
            $idAauthUser=$this->aauth->create_user($email,$password);
            $params=array(
                'nom'=> $this->input->post('nom'),
                'prenom'=> $this->input->post('prenom'),
                'id' => $idAauthUser,
                'login' => $email
                    );
            $this->EnseignantModel->add_enseignant($params);        
            $this->aauth->add_member($this->aauth->get_user_id($email),'Enseignant');
            $this->attente_confirmation($email);
            $this->email->send();
        }
        else
        {
            $data['title'] = "Inscription au rallye lecture";
            $this->load->view('AppHeader',$data);
            $this->load->view('AccountCreate',$data);
            $this->load->view('AppFooter');
        }
    }
    
    public function password_check()
    {
     $password=$this->input->post('password');
     $passwordConfirmation=$this->input->post('passwordConfirmation');
     if($password != $passwordConfirmation)
     {
         $this->form_validation->set_message('password_check','le mot de passe de confirmation est différent du mot de passe initial');
         return false;
     }
     else{
         return true;
     }
    }
    
    public function recaptcha_check($resp)
    {
        
    }
    
    public function edit()
    {
        
    }
    
    public function attente_confirmation($email)
    {
        $data['title']="Confirmation de votre inscription";
        $data['email']=$email;
        $this->load->view('AppHeader',$data);
        $this->load->view('AccountConfirmation',$data);
        $this->load->view('AppFooter');
    }
}

