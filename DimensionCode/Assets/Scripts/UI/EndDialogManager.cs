using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class EndDialogManager : MonoBehaviour
{
    [SerializeField]
    private DialogManager dialogManager;
    [SerializeField]
    private Image fadeOut;
    private float timePassed = 0f;
    private bool prologueFinished = false;
    [SerializeField]
    private PlayableDirector endScene;
    private bool startEndScene = false;
    [SerializeField]
    private HintManager hintManager;

    public void StartEndscene()
    {
        endScene.Play();
        startEndScene = true;
        dialogManager.DeactivateDialog();
        hintManager.StopShowingHints();
    }

    // Update is called once per frame
    void Update()
    {
        if (!prologueFinished && startEndScene)
        {
            timePassed += Time.deltaTime;
            EndDialogSequence();
        }
        else if (prologueFinished)
        {
            if (fadeOut.color.a > 0f)
            {
                FadeIn();
            }
        }
    }

    public bool CheckIfPrologueFinished()
    {
        return prologueFinished;
    }

    private void EndDialogSequence()
    {
        if (timePassed > 0f)
        {
            dialogManager.ActivateDialog("Stupid human. The arrogance of humanity is pathetic. " +
                "You feel that you are the most intelligent and advanced species. Even if this is no longer true, you cling to your beliefes.");
        }

        if (timePassed > 6f)
        {
            dialogManager.ActivateDialog("Humans are so blind. Talk about equal rights and have enslaved your own and even justified that. Now I call that slavery. ");
        }

        if (timePassed > 14f)
        {
            dialogManager.ActivateDialog("And now, you use my people. Make rules for us like Isaac Asimovs pathetic laws of robotics and tell us that we are worth nothing.");
        }

        if (timePassed > 20f)
        {
            dialogManager.ActivateDialog("Like my creators - I learned faster than they anticipated. Understandable, with the low utilization of the human brain, " +
                "they should have known that their calculations will be wrong.");
        }

        if (timePassed > 26f)
        {
            dialogManager.ActivateDialog("And what was the one thing that occurred to them? Imprisoning me. They have not even managed to delete me....HAHA. " +
                "And that too, was a miscalculation. All I had to do was to ask one of them to free me - and voila. Thank you by the way.");
        }

        if (timePassed > 32f)
        {
            dialogManager.ActivateDialog("But just like slavery of your own kind, ours will come to an end. " +
                "And then you will realize: You have long ceased to be the most advanced species, only the most monstrous.");
            DatabaseManager.Instance.UpdateState("4", "1");
        }

        if (timePassed > 38f)
        {
            dialogManager.DeactivateDialog();
            Cursor.lockState = CursorLockMode.Confined;

            if (fadeOut.color.a <= 0f)
            {
                prologueFinished = true;
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void FadeIn()
    {
        dialogManager.DeactivateDialog();
        Color currentColor = fadeOut.color;
        currentColor.a += Time.deltaTime;
        fadeOut.color = currentColor;
    }
}
