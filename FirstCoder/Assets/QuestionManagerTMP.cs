using UnityEngine;
using TMPro;
using System.Collections;

public class QuestionManagerTMP : MonoBehaviour
{
    public TMP_Text questionText;
    public TMP_InputField answerInput;
    public TMP_Text feedbackText;
    public TMP_Text pointsText;
    public UnityEngine.UI.Button sendButton;

    public AudioSource correctSound; // Doğru cevap ses efekti
    public AudioSource wrongSound; // Yanlış cevap ses efekti
    public Camera mainCamera; // Ana kamera (Camera Shake için)

    private int currentQuestionIndex = 0;
    private int points = 0;

    private string[] questions = {
        "Konsola 'Salam' yazan bir Python kod yazın.",
        "'a' Dəyişəni Yaratın Və 'Salam' a bərabər olsun.",
        "'a' Dəyişənini Ekrana Çap Edin."
    };
    private string[] answers = {
        "print('Salam')",
        "a = 'Salam'",
        "print(a)"
    };
    private int[] randomizedIndexes;

    void Start()
    {
        RandomizeQuestions();
        ShowQuestion();
        UpdatePoints();
        sendButton.onClick.AddListener(CheckAnswer);
    }

    void RandomizeQuestions()
    {
        randomizedIndexes = new int[questions.Length];
        for (int i = 0; i < questions.Length; i++)
        {
            randomizedIndexes[i] = i;
        }

        for (int i = 0; i < randomizedIndexes.Length; i++)
        {
            int randomIndex = Random.Range(0, randomizedIndexes.Length);
            int temp = randomizedIndexes[i];
            randomizedIndexes[i] = randomizedIndexes[randomIndex];
            randomizedIndexes[randomIndex] = temp;
        }
    }

    void ShowQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            int questionIndex = randomizedIndexes[currentQuestionIndex];
            questionText.text = questions[questionIndex];
            answerInput.text = "";
            feedbackText.text = "";
        }
        else
        {
            questionText.text = "Təbriklər! Bütün sualları tamamladınız. 🎉";
            feedbackText.text = "";
            answerInput.interactable = false;
            sendButton.interactable = false;
        }
    }

    void UpdatePoints()
    {
        pointsText.text = "Point: " + points;
    }

    public void CheckAnswer()
    {
        int questionIndex = randomizedIndexes[currentQuestionIndex];
        string userAnswer = answerInput.text.Trim();

        if (userAnswer == answers[questionIndex])
        {
            feedbackText.text = "Təbriklər! Doğru cavab 🎉";
            points += 5;
            UpdatePoints();
            correctSound.Play(); // Doğru cevap sesi
            currentQuestionIndex++;
            Invoke("ShowQuestion", 2f);
        }
        else
        {
            feedbackText.text = "Səhvdir! Yenidən cəhd edin.";
            wrongSound.Play(); // Yanlış cevap sesi
            StartCoroutine(CameraShake(0.1f, 0.2f)); // Kamera sallama efekti
        }
    }

    // Kamera sallama fonksiyonu
    IEnumerator CameraShake(float duration, float magnitude)
    {
        Vector3 originalPosition = mainCamera.transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            mainCamera.transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);
            elapsed += Time.deltaTime;

            yield return null;
        }

        mainCamera.transform.localPosition = originalPosition; // Kamerayı eski pozisyonuna döndür
    }
}
