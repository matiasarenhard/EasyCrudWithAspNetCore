using EasyCRUDTeste.Models;
using EasyCRUDTeste.ModelView;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EasyCRUDTeste.Controllers
{
    public class PessoaController : Controller
    {
        ANGULARCRUDContext db = new ANGULARCRUDContext();
        #region Buscar
        [HttpGet]
        public object BuscarPessoa()
        {
            {
                var lista = (from i in db.Pessoa
                             select new Pessoa
                             {
                                 IdPessoa = i.IdPessoa,
                                 Nome = i.Nome,
                                 Telefone = i.Telefone,
                                 Email = i.Email,
                                 Idade = i.Idade ?? 0,
                                 Skype = i.Skype,
                                 Cidade = i.Cidade,
                                 Estado = i.Estado,
                                 Portfolio = i.Portfolio,
                                 NomeBanco = i.NomeBanco,
                                 Cpf = i.Cpf,
                                 NomePessoaBanco = i.NomePessoaBanco,
                                 TipoConta = i.TipoConta,
                                 Agencia = i.Agencia,
                                 NrConta = i.NrConta,
                                 Opconta = i.Opconta,
                                 Disponibilidade = i.Disponibilidade,
                                 Horario = i.Horario,
                                 Experiencia = (from a in db.Experiencia
                                                where a.IdPessoa == i.IdPessoa
                                                select a).ToList()
                             }).ToList();

                var retorno = JsonConvert.SerializeObject(lista);
                return retorno;
            }
        }

        #endregion

        #region Gravar
        [HttpPost]
        public string GravarPessoa([FromBody] PessoaModelView Pessoa)
        {

            if (Pessoa != null)
            {
                using (ANGULARCRUDContext db = new ANGULARCRUDContext())
                {
                    Pessoa ObjPessoa = new Pessoa();
                    ObjPessoa.Nome = Pessoa.Nome;
                    ObjPessoa.Telefone = Pessoa.Telefone;
                    ObjPessoa.Email = Pessoa.Email;
                    ObjPessoa.Idade = Pessoa.Idade;
                    ObjPessoa.Skype = Pessoa.Skype;
                    ObjPessoa.Cidade = Pessoa.Cidade;
                    ObjPessoa.Estado = Pessoa.Estado;
                    ObjPessoa.Portfolio = Pessoa.Portfolio;
                    ObjPessoa.NomeBanco = Pessoa.NomeBanco;
                    ObjPessoa.Cpf = Pessoa.Cpf;
                    ObjPessoa.NomePessoaBanco = Pessoa.NomePessoaBanco;
                    ObjPessoa.TipoConta = Pessoa.TipoConta;
                    ObjPessoa.Agencia = Pessoa.Agencia;
                    ObjPessoa.NrConta = Pessoa.NrConta;
                    ObjPessoa.Opconta = Pessoa.Opconta;
                    ObjPessoa.Disponibilidade = Pessoa.Disponibilidade;
                    ObjPessoa.Horario = Pessoa.Horario;
                    db.Pessoa.Add(ObjPessoa);
                    db.SaveChanges();

                    if (Pessoa.Experiencia != null)
                    {
                        foreach (var exp in Pessoa.Experiencia)
                        {
                            Experiencia objExp = new Experiencia();
                            objExp.IdPessoa = ObjPessoa.IdPessoa;
                            objExp.Nivel = exp.Nivel;
                            objExp.Nome = exp.Nome;
                            db.Experiencia.Add(objExp);
                        }

                        db.SaveChanges();

                    }
                    return "Sucesso";
                }
            }
            else
            {
                return "Erro";
            }
        }
        #endregion

        #region Alterar
        [HttpPost]
        public string AlterarPessoa([FromBody]Pessoa Pessoa)
        {

            if (Pessoa != null)
            {
                using (ANGULARCRUDContext Con = new ANGULARCRUDContext())
                {

                    Pessoa Obj = Con.Pessoa.Where(x => x.IdPessoa == Pessoa.IdPessoa).FirstOrDefault();
                    if (Obj == null)
                        return "Está Pessoa não foi encontrada em nosso banco de dados, por favor contate o suporte.";

                    var listaExperencia = (from i in Con.Experiencia where i.IdPessoa == Pessoa.IdPessoa select i).ToList();
                    Con.Experiencia.RemoveRange(listaExperencia);

                    Obj.Email = Pessoa.Email;
                    Obj.Telefone = Pessoa.Telefone;
                    Obj.Nome = Pessoa.Nome;
                    Obj.Idade = Pessoa.Idade;
                    Obj.Skype = Pessoa.Skype;
                    Obj.Cidade = Pessoa.Cidade;
                    Obj.Portfolio = Pessoa.Portfolio;
                    Obj.NomeBanco = Pessoa.NomeBanco;
                    Obj.Cpf = Pessoa.Cpf;
                    Obj.NomePessoaBanco = Pessoa.NomePessoaBanco;
                    Obj.TipoConta = Pessoa.TipoConta;
                    Obj.Agencia = Pessoa.Agencia;
                    Obj.NrConta = Pessoa.NrConta;
                    Obj.Opconta = Pessoa.Opconta;
                    Obj.Disponibilidade = Pessoa.Disponibilidade;
                    Obj.Horario = Pessoa.Horario;
                    Con.SaveChanges();


                    if (Pessoa.Experiencia != null)
                    {
                        foreach (var exp in Pessoa.Experiencia)
                        {
                            Experiencia objExp = new Experiencia();
                            objExp.IdPessoa = Obj.IdPessoa;
                            objExp.Nivel = exp.Nivel;
                            objExp.Nome = exp.Nome;
                            Obj.Experiencia.Add(objExp);
                        }

                        Con.SaveChanges();

                    }

                    return "Sucesso";
                }
            }
            else
            {
                return "Erro";
            }
        }
        #endregion

        #region Deletar
        [HttpPost]
        public string DeletePessoa([FromBody]Pessoa Pessoa)
        {
            if (Pessoa != null)
            {
                using (ANGULARCRUDContext Con = new ANGULARCRUDContext())
                {
                    var listaExperiencia = (from xp in Con.Experiencia where Pessoa.IdPessoa == xp.IdPessoa select xp).ToList();
                    if (listaExperiencia.Count > 0 && listaExperiencia != null)
                        Con.Experiencia.RemoveRange(listaExperiencia);

                    var obj = (from i in Con.Pessoa where Pessoa.IdPessoa == i.IdPessoa select i).FirstOrDefault();
                    if (obj != null)
                        Con.Pessoa.Remove(obj);

                    Con.SaveChanges();
                    return "Sucesso";
                }
            }
            else
            {
                return "Erro";
            }
        }
        #endregion

    }
}
