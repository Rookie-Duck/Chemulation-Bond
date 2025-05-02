using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoleculeChecker : MonoBehaviour
{
    public AtomSlotTrigger[] allSlots;  // Assign semua 26 slot di sini
    public TMP_Text checkAtomText;
    public TMP_Text checkLocationText;
    public TMP_Text debugText;

    public string targetTag1 = "Atom14";
    public string targetTag2 = "Atom24";

    void Update()
    {
        CheckAnswer();
    }

    void CheckAnswer()
    {
        int hydrogenCount = 0;
        bool hIn14 = false;
        bool hIn24 = false;
        bool anyHInWrongSlot = false;
        bool hasInvalidAtom = false;
        debugText.text = ""; // kosongin dulu

        foreach (var slot in allSlots)
        {
            GameObject atom = slot.currentAtom;

            if (atom != null)
            {
                debugText.text += $"{slot.name} tag: {atom.tag}\n";

                if (atom.CompareTag("HAtom"))
                {
                    hydrogenCount++;

                    if (slot.CompareTag("Atom14"))
                        hIn14 = true;
                    else if (slot.CompareTag("Atom24"))
                        hIn24 = true;
                    else
                        anyHInWrongSlot = true;
                }
                else
                {
                    // atom bukan H → dianggap invalid
                    hasInvalidAtom = true;
                    debugText.text += $"Invalid atom detected in {slot.name}: {atom.tag}\n";
                }
            }
        }

        // Correct location jika:
        // 1. Ada 2 H
        // 2. H ada di 14 & 24
        // 3. Tidak ada H di tempat lain
        // 4. Tidak ada atom lain selain H
        bool locationCorrect = (hydrogenCount == 2) && hIn14 && hIn24 && !anyHInWrongSlot && !hasInvalidAtom;

        // Update UI
        checkLocationText.text = locationCorrect ? "Correct" : "Incorrect";
        checkAtomText.text = (hydrogenCount == 2 && !hasInvalidAtom) ? "Correct" : "Incorrect";
    }
}

