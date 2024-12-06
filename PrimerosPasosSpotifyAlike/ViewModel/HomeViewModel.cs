using CommunityToolkit.Mvvm.ComponentModel;
using PrimerosPasosSpotifyAlike.Model;
using NAudio.Wave;


namespace PrimerosPasosSpotifyAlike.ViewModel;

public partial class HomeViewModel : ObservableObject
{
	private readonly SpotiDB database;
	private WaveOutEvent output;
	private AudioFileReader audio;
	private bool isPlaying;

	public HomeViewModel(SpotiDB spotiDb)
	{
		this.database = spotiDb;
		isPlaying = false;
	}

	public void PlayAudio(Cancion cancion)
	{
		using (audio = new AudioFileReader(cancion.Ruta))
		using (output = new WaveOutEvent())
		{
			output.Init(audio);
			output.Play();
			isPlaying = true;
		}
	}

	public void PauseAudio()
	{
		if (isPlaying)
		{
			output.Pause();
		}
		else
		{
			output.Play();
		}
		//Esto cambia de true a false o de false a true y nos ahorra una linea en cada condición
		isPlaying = !isPlaying;
    }

	//Este método nos para el audio completamente y limpia recursos
	public void StopAudio()
	{
        if (audio != null && output != null)
        {
            output?.Stop();
            audio?.Dispose();
            output?.Dispose();
			output = null;
			audio = null;
			isPlaying = false;
        }
        
	}

}