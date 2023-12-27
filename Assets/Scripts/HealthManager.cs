using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private int _currentHealth;
    private int[] dotArray = new int[12];
    // private List<int> dotList = new List<int>(); // заменить нижнюю версию на эту
    [SerializeField] private List<int> dotList = new List<int>();

    private bool hasAnActiveDot = false;

    void Update()
    {
        // if (_currentHealth < 0)
        //     _currentHealth = 0;
        if ( dotList.Count > 0 && !hasAnActiveDot )
            StartCoroutine(TakeDamageOvetTime());
        _healthText.text = _currentHealth.ToString();
    }

    public void IncreaseHealth(int healing){
        _currentHealth += healing;
    }

    public void TakeDirectDamage(int damage)
    {
        _currentHealth -= damage;
    }

    IEnumerator TakeDamageOvetTime(){
        hasAnActiveDot = true;
        while ( dotList.Count > 0 ){
            // print("before yield");
            yield return new WaitForSeconds(1);
            // print("after yield");
            _currentHealth -= dotList[0];
            dotList.RemoveAt(0);
        }
        hasAnActiveDot = false;
    }

    public void ApplyDOT(int dotDamage, int dotTimes){
        // RefreshDOTList();
        // print("DOTDamage: " + dotDamage);
        // print("DOTTimes: " + dotTimes);
        // print("Count: " + dotList.Count);

        for ( int i = 0 ; i < dotList.Count && dotTimes > 0 ; i++, dotTimes--){
            dotList[i] += dotDamage;
            // print("for sum cycle");
        }
        for (; dotTimes > 0 ; dotTimes--){
            dotList.Add(dotDamage);
            // print("for add cycle");
        }

        // while ( dotTimes > 0 ){
        //     dotList.Add(dotDamage);
        //     print("while add cycle");
        //     dotTimes--;
        // }

        // for ( int i = 0; i < dotTimes; i++){
        //     if ( dotList[i] != null )
        //         dotArray[i] += dotDamage;
        //     else
        //         dotList.Add(dotDamage);
        // }

        // print("Count: " + dotList.Count);
        // dotList.ForEach(NewPrint);
        // foreach( int dmg in dotList ){
        //     print(dmg);
        // }
        // StartCoroutine(TakeDamageOvetTime());
        // for ( int i = 0; dotArray[i] != 0; i++ ){
        //     StartCoroutine(TickTimer());
        //     TakeDamageOvetTime(dotArray[i]);
        //     dotArray[i] = 0;
        // }
        // while ( dotArray[i] != 0 ){
        //     StartCoroutine(TickTimer());
        //     TakeDamageOvetTime(dotArray[i]);
        //     dotArray[i] = 0;
        //     i++;
        // }
    }

    // public void RefreshDOTList(){
    //     while ( dotList.Contains(0) )
    //         dotList.Remove(0);
    //     // for ( int i = 0 ; dotList[i] != 0 ; i++ ){
    //     //     dotList.Re
    //     // }
    // }

    // public void NewPrint(int t){
    //     print(t);
    // }
    // public IEnumerator TickTimer(){
    //     yield return new WaitForSeconds(1);
    // }
}
