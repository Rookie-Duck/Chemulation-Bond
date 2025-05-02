using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoleculeChecker : MonoBehaviour
{
    public AtomSlotTrigger[] allSlots;  // Assign semua 26 slot di sini
    public TMP_Text checkAtomText;
    public TMP_Text checkLocationText;
    public TMP_Text statusText;

    void Update()
    {
        CheckAnswer();
    }

    void CheckAnswer()
    {
        int hydrogenCount = 0;
        bool hIn14 = false;
        bool hIn24 = false;
        bool hIn10 = false;  // Tambahkan pengecekan untuk Atom10
        bool hIn22 = false;  // Tambahkan pengecekan untuk Atom22
        bool anyHInWrongSlot = false;
        bool hasInvalidAtom = false;

        foreach (var slot in allSlots)
        {
            GameObject atom = slot.currentAtom;

            if (atom != null)
            {
                if (atom.CompareTag("HAtom"))
                {
                    hydrogenCount++;

                    if (slot.CompareTag("Atom14"))
                        hIn14 = true;
                    else if (slot.CompareTag("Atom24"))
                        hIn24 = true;
                    else if (slot.CompareTag("Atom10"))  // Cek Atom10
                        hIn10 = true;
                    else if (slot.CompareTag("Atom22"))  // Cek Atom22
                        hIn22 = true;
                    else
                        anyHInWrongSlot = true;
                }
                else
                {
                    hasInvalidAtom = true;
                }
            }
        }

        // Cek jika ada H di Atom14 dan Atom24, atau di Atom10 dan Atom22
        bool locationCorrect = ((hIn14 && hIn24) || (hIn10 && hIn22)) && !anyHInWrongSlot;
        bool atomCorrect = (hydrogenCount == 2) && !hasInvalidAtom;

        // Update Location Text
        checkLocationText.text = locationCorrect ? "Correct" : "Incorrect";
        checkLocationText.color = locationCorrect ? Color.green : Color.red;

        // Update Atom Text
        checkAtomText.text = atomCorrect ? "Correct" : "Incorrect";
        checkAtomText.color = atomCorrect ? Color.green : Color.red;

        if (locationCorrect && atomCorrect)
        {
            statusText.text = "Passed";
            statusText.color = Color.green;
        }
        else
        {
            statusText.text = "On Going";
            statusText.color = new Color(0.9607844f, 0.6431373f, 0.03137255f); // Orange
        }
    }
}

