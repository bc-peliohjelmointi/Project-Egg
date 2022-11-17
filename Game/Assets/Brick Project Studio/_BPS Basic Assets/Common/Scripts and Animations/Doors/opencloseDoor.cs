using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

namespace UnityEngine

{
	public class opencloseDoor : MonoBehaviour
	{

		public Animator openandclose;
        private StarterAssetsInputs _input;
        public bool open;
		public Transform Player;

		void Start()
		{
            _input = GetComponent<StarterAssetsInputs>();
            open = false;
		}

		void OnBecameVisble()
		{
			{
				if (Player)
				{
					float dist = Vector3.Distance(Player.position, transform.position);
					if (dist < 15)
					{

						if (open == false)
						{
							if (_input.interact)
							{
								StartCoroutine(opening());
							}
						}
						else
						{
							if (open == true)
							{
								if (_input.interact)
								{
									StartCoroutine(closing());
								}
							}

						}

					}
				}

			}

		}

		IEnumerator opening()
		{
			print("you are opening the door");
			openandclose.Play("Opening");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			openandclose.Play("Closing");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}