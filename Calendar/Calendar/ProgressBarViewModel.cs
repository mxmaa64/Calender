using System; 
using System.ComponentModel;
using Xamarin.Forms;


namespace Calendar
{
    class ProgressBarViewModel: INotifyPropertyChanged
    {
        public ProgressBarViewModel()
 		{ 
 		} 

 		private bool isIndeterminate; 
 
 		public bool IsIndeterminate 
 		{ 
 			get { return isIndeterminate; } 
 			set { isIndeterminate = value; OnPropertyChanged("IsIndeterminate"); }

 		} 

 		private float progress = 0.0f; 
 
 		public float Progress
 		{ 
 			get { return progress; } 
 			set { 
 				progress = value; 
 				OnPropertyChanged("Progress"); 
 			} 
 		} 
 
 		private double speed = 100; 
 		public double SpeedF
 		{ 
 			get { return speed; } 
 			set { 
 				if (Math.Abs (speed - value) < double.Epsilon) 
 					return; 
 

 				speed = value; 
 				OnPropertyChanged("Speed"); 
 			} 
 		} 
 		public int Speed
 		{ 
 			get { return (int)speed; } 
 		} 
 

 		private Command toggleIndeterminateCommand; 
 		public Command ToggleIndeterminateCommand
 		{ 
 			get { return toggleIndeterminateCommand ??  
 				(toggleIndeterminateCommand = new Command(ExecuteToggleIndeterminateCommand)); } 
 		} 
 
 		private void ExecuteToggleIndeterminateCommand()
 		{ 
 			IsIndeterminate = !IsIndeterminate; 
 		} 
 
 		private Command<string> addProgressCommand; 
 		public Command AddProgressCommand
 		{ 
 			get { return addProgressCommand ?? (addProgressCommand = new Command<string> (ExecuteAddProgressCommand)); } 
 		} 
 
 		private void ExecuteAddProgressCommand(string toAdd)
 		{ 
 			float addThis = 0.0F; 
 			if(float.TryParse(toAdd, out addThis)) 
 				Progress += addThis; 
 		} 

 		public Color ProgressColor
 		{ 
 			get { return Color.FromHex ("3498DB"); } 
 		} 
 
 		public Color ProgressBackgroundColor
 		{ 
 			get { return Color.FromHex ("B4BCBC"); } 
 		} 
 

 		#region INotifyPropertyChanged implementation 
 		public event PropertyChangedEventHandler PropertyChanged; 
 		#endregion 

 		public void OnPropertyChanged(string propertyname)
 		{ 
 			if (PropertyChanged == null) 
 				return; 
 

 			PropertyChanged(this, new PropertyChangedEventArgs(propertyname)); 
 		} 
 	} 
}
