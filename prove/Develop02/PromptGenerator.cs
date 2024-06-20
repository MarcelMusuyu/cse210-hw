using System;

public class PromptGenerator{
    //The constructor
    public PromptGenerator(){

    }
    public List<string> _prompts= new List<string>();

    public string GetRandomPrompt(){
        Random randomGenerator= new Random();
        int index= randomGenerator.Next(0,_prompts.Count-1);
        return _prompts[index];
    }
}