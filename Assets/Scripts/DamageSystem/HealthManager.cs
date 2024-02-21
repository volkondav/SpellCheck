using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.Assertions;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int _currentHealth;
    [SerializeField] private int[] damageReduction = new int[2]; // первое значение -- это снижение прямого урона, второе -- периодического
    // private int[] dotArray = new int[12];
    // private List<int> dotList = new List<int>(); // заменить нижнюю версию на эту
    [SerializeField] private List<int> dotList = new List<int>();
    private TextMeshProUGUI _healthText;

    private bool hasAnActiveDot = false;

    void Awake(){
        
        // выглядит страшно, согласен, но пока не знаю лучшего способа получить референс на объект HealthPoints
        // пока просто пусть HealthPoints будет первым объектом в объекте Canvas
        Assert.IsTrue( this.transform.GetChild(0).GetChild(0).GetChild(0).TryGetComponent<TextMeshProUGUI>(out _healthText),
                                "HealthPoints object was not found at the specified index of 0,0 in the hierarchy" );
    }

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

    public void UpdateDamageReductionValues( int[] newDamageReductionValues ){
        for (int i = 0; i < damageReduction.Length ; i++)
            damageReduction[i] = newDamageReductionValues[i];
    }

    public void TakeDirectDamage(int damage)
    {
        if ( damage - damageReduction[0] > 0 )
            _currentHealth -= ( damage - damageReduction[0] ) ;
    }

    IEnumerator TakeDamageOvetTime(){
        hasAnActiveDot = true;
        while ( dotList.Count > 0 ){
            // print("before yield");
            yield return new WaitForSeconds(1);
            // print("after yield");
            if ( dotList[0] - damageReduction[1] > 0 )
                _currentHealth -= ( dotList[0] - damageReduction[1] );
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
