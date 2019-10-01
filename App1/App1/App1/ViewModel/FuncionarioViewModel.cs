using App1.Infra;
using App1.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.ViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public class FuncionarioViewModel : ViewModelBase
    {
        #region props
        public int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                this.Notify("Id");
            }
        }

        public string nome;
        public string Nome
        {
            get { return nome; }
            set
            {
                nome = value;
                this.Notify("Nome");
            }
        }

        public string cargo;
        public string Cargo
        {
            get { return cargo; }
            set
            {
                cargo = value;
                this.Notify("Cargo");
            }
        }

        public string salario;
        public string Salario
        {
            get { return salario; }
            set
            {
                salario = value;
                this.Notify("Salario");
            }
        }

        public string codigoMoeda;
        public string CodigoMoeda
        {
            get { return codigoMoeda; }
            set
            {
                codigoMoeda = value;
                this.Notify("CodigoMoeda");
            }
        }
         
        #endregion props

        private readonly Infra.INavigatioService _navigatioService;

        public FuncionarioViewModel()
        {
            this.GravarCommand = new Command(this.Gravar);
            this.ExcluirCommand = new Command(this.Excluir);
            this._navigatioService = DependencyService.Get<Infra.INavigatioService>();

            this.CarregaFuncionarios();

            this.CarregaListaMoedas();
        }

        #region Picker moedas
        public class Moeda
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }



        public List<Moeda> ListMoedas { get; set; }

        private void CarregaListaMoedas()
        {
            Moedas retorno = new ServicoWEB().GetMoedas();

            ListMoedas = new List<Moeda>();
            foreach (var item in retorno.value)
            {
                ListMoedas.Add(new Moeda() { Key = item.simbolo, Value = item.nomeFormatado });
            }
        }

        Moeda selectedMoeda;
        public Moeda SelectedMoeda
        {
            get { return selectedMoeda; }
            set
            {
                if (SelectedMoeda != value)
                {
                    selectedMoeda = value;
                    this.Notify("SelectedMoeda");
                }
            }
        }


        #endregion

        #region Gravar
        public ICommand GravarCommand
        {
            get;
            set;
        }

        private void Gravar()
        {
            Funcionario obj = new Funcionario()
            {
                Id = this.Id,
                Nome = this.Nome,
                Cargo = this.Cargo,
                Salario = this.Salario,
                CodigoMoeda = this.SelectedMoeda.Key
            };

            if (this.Nome.Trim() != "" && this.Cargo.Trim() != "" && this.Salario.Trim() != "")
            {
                Repository<Funcionario> rep = new Repository<Funcionario>();
            
                var retorno = rep.Save(obj, "MUDAR");

                if (retorno == 1)
                {
                    if (this.Id == 0)
                    {
                        ListaFuncionario.Add(obj); 
                    }
                    else
                    {
                        Funcionario item = ListaFuncionario.Where(a => a.Nome == this.Nome).ToList()[0];

                        ListaFuncionario.Remove(item);

                        ListaFuncionario.Add(obj);
                    }

                    this.Id = 0;
                    this.Nome = "";
                    this.Cargo = "";
                    this.Salario = "";
                }
            }
        }
        #endregion

        #region Excluir
         
        public ICommand ExcluirCommand
        {
            get;
            set;
        }

        private void Excluir()
        {
            if (!string.IsNullOrEmpty(this.Nome))
            {
                Funcionario item = ListaFuncionario.Where(a => a.Nome == this.Nome).ToList()[0];

                ListaFuncionario.Remove(item);

                Repository<Funcionario> rep = new Repository<Funcionario>();
  
                rep.Delete(item, "MUDAR");

                this.Id = 0;
                this.Nome = "";
                this.Cargo = "";
                this.Salario = "";
            }
        }

        #endregion
        
        #region GridView

        public ObservableCollection<Funcionario> ListaFuncionario { get; private set; } = new ObservableCollection<Funcionario>();

        private void CarregaFuncionarios()
        {
            ListaFuncionario.Clear();

            List<Funcionario> listFuncionarioModel = new List<Funcionario>();

            try
            {
                var repT = new Repository<Funcionario>();

                listFuncionarioModel = repT.Collection("MUDAR").ToList();


            }
            catch
            {

            }

            ListaFuncionario = new ObservableCollection<Funcionario>(listFuncionarioModel); 
        }

      
        #region Selecionar Item na lista 

        public Funcionario selecionado { get; set; }

        public Funcionario _selectedItem { get; set; }

        public Funcionario SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                try
                {
                    _selectedItem = value;

                    if (_selectedItem != null)
                    {
                        selecionado = new Repository<Funcionario>().Find(l => (l.Nome == _selectedItem.Nome), "MUDAR");

                        this.Id = selecionado.Id;
                        this.Nome = selecionado.Nome;
                        this.Cargo = selecionado.Cargo;
                        this.Salario = selecionado.Salario; 
                    }
                }
                catch
                {
                }
            }
        }

        #endregion

        #endregion
    }
}
