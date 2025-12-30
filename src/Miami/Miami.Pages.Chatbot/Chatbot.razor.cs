using Microsoft.AspNetCore.Components;

namespace Miami.Pages.Chatbot;

public partial class Chatbot
{
    private List<ChatMessage> messages = new();
    private string userInput = string.Empty;
    private bool isTyping = false;
    private ElementReference chatContainer;

    private readonly List<string> botResponses = new()
    {
        "That's interesting! Tell me more.",
        "I see what you mean! ??",
        "Fascinating! I never thought of it that way.",
        "Hmm, let me think about that for a moment...",
        "That's a great point!",
        "I totally agree with you! ??",
        "Could you elaborate on that?",
        "That reminds me of something... but I forgot what! ??",
        "You're absolutely right!",
        "I'm not sure I understand, but it sounds cool!",
        "Wow, that's really something!",
        "Tell me more about your thoughts on this.",
        "I appreciate you sharing that with me!",
        "That's quite insightful!",
        "Interesting perspective! ??",
        "I'm here to listen! Keep going.",
        "That's definitely worth considering.",
        "I love how you think!",
        "You've given me something to ponder.",
        "Great question! Let me think...",
        "I couldn't have said it better myself!",
        "That's one way to look at it!",
        "You're making me think differently now.",
        "I'm learning so much from you!",
        "That's a brilliant observation!",
        "Keep those thoughts coming!",
        "I'm all ears! ??",
        "You have a unique way of seeing things.",
        "That's worth exploring further!",
        "I'm impressed by your insight!"
    };

    private readonly Random random = new();

    protected override void OnInitialized()
    {
        // Welcome message
        messages.Add(new ChatMessage
        {
            Text = "Hi there! ?? I'm a simple chatbot. I'll respond with random messages to keep our conversation fun! What's on your mind?",
            IsUser = false,
            Timestamp = DateTime.Now
        });
    }

    private async Task SendMessage()
    {
        if (string.IsNullOrWhiteSpace(userInput))
            return;

        // Add user message
        messages.Add(new ChatMessage
        {
            Text = userInput.Trim(),
            IsUser = true,
            Timestamp = DateTime.Now
        });

        userInput = string.Empty;

        // Show typing indicator
        isTyping = true;
        StateHasChanged();

        // Simulate bot "thinking" time
        await Task.Delay(random.Next(800, 2000));

        // Add random bot response
        messages.Add(new ChatMessage
        {
            Text = GetRandomResponse(),
            IsUser = false,
            Timestamp = DateTime.Now
        });

        isTyping = false;
        StateHasChanged();
    }

    private async Task SendQuickMessage(string message)
    {
        userInput = message;
        await SendMessage();
    }

    private void ClearChat()
    {
        messages.Clear();
        messages.Add(new ChatMessage
        {
            Text = "Chat cleared! Let's start fresh. What would you like to talk about?",
            IsUser = false,
            Timestamp = DateTime.Now
        });
        StateHasChanged();
    }

    private string GetRandomResponse()
    {
        return botResponses[random.Next(botResponses.Count)];
    }

    private class ChatMessage
    {
        public string Text { get; set; } = string.Empty;
        public bool IsUser { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
