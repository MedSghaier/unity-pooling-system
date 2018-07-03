//Generic poooling system for vatious types of gameObjects 

public class NewGenericObjectPooler : MonoBehaviour{

	public static NewGenericObjectPooler current ;
	public GameObject pooledObject ;
	public int pooledAmount = 20 ;
	public boool willGrow = true ; // determins if we will create an unavailble called object 
									// basically determins expandipality of the pool

	List<GameObject> pooledObjects ;

	vioid Awake()
	{
		current = this;
	}
	void Strat(){
		pooledObjects = new List<GameObject>();

		for(int i =0; i<poolerAmount ; i++){
			GameObject obj = (GameObject)Instansiate(pooledObject);
			obj.SetActive(false);
			pooledObjects.Add(obj);
		}
	}

	public GameObject GetpooledObject ()
	{
		for (int i = 0 ; i< pooledObjects.Count; i++){
			if(!pooledObjects[i].activeInHierarchy){
				return pooledObjects[i] ;
			}

		}

		if(willGrow){
			GameObject obj = (GameObject)Instansiate(pooledObject);
			pooledObjects.Add(obj);
			return obj;
		}

		return null;
	}

}

/////// Calling this script from another script (fire methode exple)


void Fire(){

	GameObject obj = new NewGenericObjectPooler.current.GetpooledObject();
	if(obj==null) return ;

	obj.transform.position = transform.position ;
	obj.transform.rotation = transform.rotation ;
	obj.SetActive (true);
} 

//////////////////Bullet destroyer Script 

void OnEnable(){ // called when the object is visible on the screen
	Invoke("Destroy",2f); // object will be destroyer after 2 seconds
}

void Destroy(){
	gameobject.SetActive(false);
}

void OnbDisabled() //called when the object is visible on the screen
{
	CancelInvoke();
}


