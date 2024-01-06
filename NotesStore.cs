/*
1. C#: Notes Store

In this challenge, the task is to implement a class called NotesStore. The class will manage a collection of notes,
with each note having a state and a name. Valid states for notes are 'completed', 'active', and 'others'. All other
states are invalid.

The class must have the following methods:

1. AddNote(state, name): adds a note with the given name (string) and state (string) to the collection. In addition to that:
o If the passed name is empty, then it throws an Exception with the message 'Name cannot be empty'.
o If the passed name is non-empty but the given state is not a valid state for a note, then it throws an Exception
with the message 'Invalid state {state}'.
2. GetNotes(state): returns a list of note names with the given state (string) added so far. The names are returned in
the order the corresponding notes were added. In addition to that:
o If the given state is not a valid note state, then it throws an Exception with the message 'Invalid state {state}'.
o If no note is found in this state, it returns an empty list.

Note: The state names are case-sensitive.

Your implementation of the function will be tested by a stubbed code on several input files. Each input file
contains parameters for the function calls. The functions will be called with those parameters, and the result of
their executions will be printed to the standard output by the stubbed code. The stubbed code joins the strings
returned by the GetNotes function with a comma and prints to the standard output. If GetNotes returns an
empty list, the stubbed code prints 'No Notes'. The stubbed code also prints messages of all the thrown errors.
*/ 


using System;
using System.Collections.Generic;
using System.IO;

namespace Solution
{

    public class Note
    {
        public string State { get; set; }
        public string Name { get; set; }
    }
    public class NotesStore
    {
       private List<Note> notes;

        public NotesStore()
        {
            notes = new List<Note>();
        }

        public void AddNote(string state, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Name cannot be empty");
            }

            if (!IsValidState(state))
            {
                throw new Exception($"Invalid state {state}");
            }

            notes.Add(new Note { State = state, Name = name });
        }

        public List<string> GetNotes(string state)
        {
            if (!IsValidState(state))
            {
                throw new Exception($"Invalid state {state}");
            }

            List<string> result = new List<string>();
            foreach (var note in notes)
            {
                if (note.State == state)
                {
                    result.Add(note.Name);
                }
            }

            return result.Count > 0 ? result : new List<string> { "No Notes" };
        }

        private bool IsValidState(string state)
        {
            return state == "completed" || state == "active" || state == "others";
        }
    } 

    public class Solution
    {
        public static void Main() 
        {
            var notesStoreObj = new NotesStore();
            var n = int.Parse(Console.ReadLine());
            for (var i = 0; i < n; i++) {
                var operationInfo = Console.ReadLine().Split(' ');
                try
                {
                    if (operationInfo[0] == "AddNote")
                        notesStoreObj.AddNote(operationInfo[1], operationInfo.Length == 2 ? "" : operationInfo[2]);
                    else if (operationInfo[0] == "GetNotes")
                    {
                        var result = notesStoreObj.GetNotes(operationInfo[1]);
                        if (result.Count == 0)
                            Console.WriteLine("No Notes");
                        else
                            Console.WriteLine(string.Join(",", result));
                    } else {
                        Console.WriteLine("Invalid Parameter");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }
    }
}
