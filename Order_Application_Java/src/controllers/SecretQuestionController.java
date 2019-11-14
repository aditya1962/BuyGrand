/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controllers;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Aditya
 */
public class SecretQuestionController {
    private List <String> secretQuestionList;
    
    public void setSecretQuestions()
    {
        secretQuestionList = new ArrayList <String>();
        secretQuestionList.add("What is your favorite car model?");
        secretQuestionList.add("What is your pet's name?");
        secretQuestionList.add("What is your favorite movie?");
        secretQuestionList.add("What is your favorite friend's maiden name?");
        secretQuestionList.add("What is your favorite holiday location?");
    }
    
    public List <String> getQuestions()
    {
        return secretQuestionList;
    }
}
