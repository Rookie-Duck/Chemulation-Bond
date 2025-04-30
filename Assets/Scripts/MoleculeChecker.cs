using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoleculeChecker : MonoBehaviour
{
    public TMP_Text checkAtomText; // UI TextMeshPro untuk memeriksa atom
    public TMP_Text checkLocationText; // UI TextMeshPro untuk memeriksa lokasi

    private int hydrogenCount = 0; // Menghitung jumlah HAtom yang terdeteksi

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HAtom") && other.CompareTag("Atom14") || other.CompareTag("Atom24"))
        {
            checkAtomText.text = "Correct";
            checkLocationText.text = "Correct";
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        // Cek apakah objek yang keluar adalah HAtom
        if (other.CompareTag("HAtom"))
        {
            --hydrogenCount; // Kurangi jumlah HAtom yang terdeteksi
            CheckMolecule(); // Periksa kembali setelah HAtom keluar
        }
    }

    private void CheckMolecule()
    {
        // Cek apakah ada tepat 2 HAtom
        bool correctAtoms = hydrogenCount == 2;

        // Cek apakah HAtom berada di lokasi yang benar
        bool correctLocation = gameObject.CompareTag("Atom14") && gameObject.CompareTag("Atom24");

        // Update UI berdasarkan hasil pemeriksaan
        checkAtomText.text = correctAtoms ? "Correct" : "Incorrect";
        checkLocationText.text = correctLocation ? "Correct" : "Incorrect";
    }*/
}
