using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Miami.App.Pages;

public partial class Home
{
    private int currentSlide = 0;
    private ElementReference servicesSection;

    protected override async Task OnInitializedAsync()
    {
        // Start auto-play carousel
        _ = AutoPlayCarousel();
    }

    private void NextSlide()
    {
        currentSlide = (currentSlide + 1) % 3;
        StateHasChanged();
    }

    private void PreviousSlide()
    {
        currentSlide = currentSlide == 0 ? 2 : currentSlide - 1;
        StateHasChanged();
    }

    private void GoToSlide(int index)
    {
        currentSlide = index;
        StateHasChanged();
    }

    private async Task AutoPlayCarousel()
    {
        while (true)
        {
            await Task.Delay(5000); // Change slide every 5 seconds
            NextSlide();
        }
    }

    private async Task ScrollToServices()
    {
        // Scroll to services section
        try
        {
            await Task.Delay(100);
            // In a real implementation, you would use JS Interop to scroll
            // For now, this is a placeholder
        }
        catch
        {
            // Handle any errors
        }
    }
}
