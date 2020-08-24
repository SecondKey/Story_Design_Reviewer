using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Story_Design_Reviewer.ViewModel
{
    public class ErrorPageViewModel : ViewModelBase
    {
        public ErrorPageViewModel()
        {
            Models.ProcessElement p1 = new Models.ProcessElement("博丽灵梦博丽灵梦博丽灵梦博丽灵梦博丽灵梦博丽灵梦", null);
            Models.ProcessElement p2 = new Models.ProcessElement("p2", p1);
            Models.ProcessElement p3 = new Models.ProcessElement("p3", p2);
            ErrorList.Add(new ErrorElementModel(ErrorType.LostMotivation, p1));
            ErrorList.Add(new ErrorElementModel(ErrorType.LostMotivation, p2));
            ErrorList.Add(new ErrorElementModel(ErrorType.LostMotivation, p3));
            ErrorList.Add(new ErrorElementModel(ErrorType.LostMotivation, p3));

            ConflictList.Add(new ErrorElementModel(ErrorType.LostMotivation, p1));
            ConflictList.Add(new ErrorElementModel(ErrorType.LostMotivation, p2));
            ConflictList.Add(new ErrorElementModel(ErrorType.LostMotivation, p3));
            ConflictList.Add(new ErrorElementModel(ErrorType.LostMotivation, p3));

            PromptList.Add(new ErrorElementModel(ErrorType.LostMotivation, p1));
            PromptList.Add(new ErrorElementModel(ErrorType.LostMotivation, p2));
            PromptList.Add(new ErrorElementModel(ErrorType.LostMotivation, p3));
            PromptList.Add(new ErrorElementModel(ErrorType.LostMotivation, p3));

            TODOList.Add(new ErrorElementModel(ErrorType.LostMotivation, p1));
            TODOList.Add(new ErrorElementModel(ErrorType.LostMotivation, p2));
            TODOList.Add(new ErrorElementModel(ErrorType.LostMotivation, p3));
            TODOList.Add(new ErrorElementModel(ErrorType.LostMotivation, p3));

        }

        private ObservableCollection<ErrorElementModel> errorList = new ObservableCollection<ErrorElementModel>();
        public ObservableCollection<ErrorElementModel> ErrorList
        {
            get { return errorList; }
            set
            {
                errorList = value;
                RaisePropertyChanged(() => ErrorList);
            }
        }

        private List<ErrorElementModel> conflictList = new List<ErrorElementModel>();
        public List<ErrorElementModel> ConflictList
        {
            get { return conflictList; }
            set
            {
                conflictList = value;
                RaisePropertyChanged(() => ConflictList);
            }
        }

        private List<ErrorElementModel> promptList = new List<ErrorElementModel>();
        public List<ErrorElementModel> PromptList
        {
            get { return promptList; }
            set
            {
                promptList = value;
                RaisePropertyChanged(() => PromptList);
            }
        }


        private List<ErrorElementModel> todoList = new List<ErrorElementModel>();
        public List<ErrorElementModel> TODOList
        {
            get { return todoList; }
            set
            {
                todoList = value;
                RaisePropertyChanged(() => TODOList);
            }
        }

        private string errorInformation;
        public string ErrorInformation
        {
            get { return errorInformation; }
            set
            {
                errorInformation = value;
                RaisePropertyChanged(() => ErrorInformation);
            }
        }


        private int selectedList;
        public int SelectList
        {
            get { return selectedList; }
            set
            {
                selectedList = value;
                switch (value)
                {
                    case 0:
                        SelectedError = 0;
                        break;
                    case 1:
                        SelectConflict = 0;
                        break;
                    case 2:
                        SelectPrompt = 0;
                        break;
                    case 3:
                        SelectTODO = 0;
                        break;
                    default:
                        break;
                }
                RaisePropertyChanged(() => SelectList);
            }
        }

        private int selectedError = 0;
        public int SelectedError
        {
            get { return selectedError; }
            set
            {
                selectedError = value;
                ItemClick();
                RaisePropertyChanged(() => SelectedError);
            }
        }

        private int selectConflict = 0;
        public int SelectConflict
        {
            get { return selectConflict; }
            set
            {
                selectConflict = value;
                ItemClick();
                RaisePropertyChanged(() => SelectConflict);
            }
        }

        private int selectPrompt = 0;
        public int SelectPrompt
        {
            get { return selectPrompt; }
            set
            {
                selectPrompt = value;
                ItemClick();
                RaisePropertyChanged(() => SelectPrompt);
            }
        }

        private int selectTODO = 0;
        public int SelectTODO
        {
            get { return selectTODO; }
            set
            {
                selectTODO = value;
                ItemClick();
                RaisePropertyChanged(() => SelectTODO);
            }
        }

        public void ItemClick()
        {
            switch (SelectList)
            {
                case 0:
                    ErrorInformation = ErrorList[SelectedError].ErrorInfo;
                    break;
                case 1:
                    ErrorInformation = ConflictList[SelectConflict].ErrorInfo;
                    break;
                case 2:
                    ErrorInformation = PromptList[SelectPrompt].ErrorInfo;
                    break;
                case 3:
                    ErrorInformation = TODOList[SelectTODO].ErrorInfo;
                    break;
            }
        }

        public RelayCommand TestCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Models.ProcessElement p123 = new Models.ProcessElement("p123", null);
                    ErrorList.Add(new ErrorElementModel(ErrorType.LostMotivation, p123));
                });
            }
        }

    }
}
