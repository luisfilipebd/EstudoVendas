using System;
using System.IO;
using System.Collections;
using System.Text;
using System.Collections.Generic;

public class ConfigIni : IDisposable
{
    // usado para carregar todos os valores (key=value)
    private Hashtable keyPairs = new Hashtable();

    // nome do arquivo .ini
    private string arquivo;

    // seção padrão dentro do arquivo ini (para facilitar algumas situações)
    private const string SECAO_CONFIG = "Config";

    public struct SectionPair
    {
        public string Section;
        public string Key;
    }

    /// <summary>
    /// Essa função inicializa um arquivo de configuração que pode existir ou não
    /// </summary>
    /// <param name="arquivoConfig">Caminho completo para o arquivo .ini (pode ser outra extensão)</param>
    public ConfigIni(string arquivoConfig)
    {
        this.Ler(arquivoConfig);
    }

    #region leitura do arquivo
    /// <summary>
    /// Faz a leitura do arquivo de configuração. Por padrão ao instanciar a classe ConfigIni o arquivo já é lido
    /// </summary>
    /// <param name="arquivoConfig">Caminho completo para o arquivo .ini (pode ser outra extensão)</param>
    public void Ler(string arquivoConfig)
    {
        // guarda na variável interna para futuras consultas
        arquivo = arquivoConfig;

        if (!File.Exists(arquivo))
        {
            return;
        }

        TextReader iniFile = null;

        try
        {
            iniFile = new StreamReader(arquivo);

            string strLine = iniFile.ReadLine();
            string currentRoot = null;

            // percorre cada linha do arquivo até o final
            while (strLine != null)
            {
                strLine = strLine.Trim();

                if (!string.IsNullOrEmpty(strLine))
                {
                    // se a linha inicia e finaliza com [ e ] é uma seção, neste caso setamos uma variável para indicar em que seção estamos
                    // será usada para gravar na Hashtable para localização futura
                    if (strLine.StartsWith("[") && strLine.EndsWith("]"))
                    {
                        currentRoot = strLine.Substring(1, strLine.Length - 2);
                    }
                    else
                    {
                        // aqui vamos separar chave de valor (sinal de = é o separador)
                        string[] keyPair = strLine.Split(new char[] { '=' }, 2);

                        // SectionPar tem por "chave-primária" a seção atual e chave da linha que lemos
                        SectionPair sectionPair;
                        string value = null;

                        // se não temos uma seção atual, vamos definir como "ROOT"
                        if (currentRoot == null)
                            currentRoot = "ROOT";

                        sectionPair.Section = currentRoot;
                        sectionPair.Key = keyPair[0];

                        // se tem valor vamos defini-la, caso contrario será null
                        if (keyPair.Length > 1)
                            value = keyPair[1];

                        // guarda na Hashtable
                        keyPairs.Add(sectionPair, value);
                    }
                }

                // vamos a próxima linha
                strLine = iniFile.ReadLine();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (iniFile != null)
                iniFile.Close();
        }
    }
    #endregion

    #region funções de conversão de tipos
    // função usada internamente para tentar converter um string em inteiro e se não conseguir retorna o valor padrão
    private int ToInt(string st, int padrao)
    {
        int i;
        if (!int.TryParse(st, out i))
            i = padrao;
        return i;
    }

    // função usada internamente para tentar converter um string em decimal e se não conseguir retorna o valor padrão
    private decimal ToDecimal(string st, decimal padrao)
    {
        decimal d;
        if (!decimal.TryParse(st, out d))
            d = padrao;
        return d;
    }

    // função usada internamente para tentar converter um string em data e se não conseguir retorna o valor padrão
    private DateTime ToDate(string st, DateTime padrao)
    {
        DateTime dt;
        if (!DateTime.TryParse(st, out dt))
            dt = padrao;
        return dt;
    }
    #endregion

    #region funções auxiliares
    // função auxiliar que vai retornar o par que contem o valor de uma seção/chave
    private SectionPair GetSectionPair(string secao, string chave)
    {
        foreach (SectionPair pair in keyPairs.Keys)
        {
            if (pair.Section.ToUpper().Equals(secao.ToUpper()) && pair.Key.ToUpper().Equals(chave.ToUpper()))
            {
                return pair;
            }
        }

        return new SectionPair() { Section = string.Empty };
    }

    // esta função retorna uma matriz com todas as chaves de uma seção
    private string[] EnumSection(string secao)
    {
        ArrayList tmpArray = new ArrayList();

        foreach (SectionPair pair in keyPairs.Keys)
        {
            if (pair.Section.ToUpper().Equals(secao.ToUpper()))
                tmpArray.Add(pair.Key);
        }

        return (string[])tmpArray.ToArray(typeof(string));
    }

    /// <summary>
    /// Exclui uma chave com seu valor de dentro de uma seção (se existir)
    /// </summary>
    /// <param name="secao">Nome da seção</param>
    /// <param name="chave">Nome da chave</param>
    public void RemoverChave(string secao, string chave)
    {
        // busca o pair (secao/chave)
        SectionPair pair = GetSectionPair(secao, chave);

        // se encontrou remove
        if (!string.IsNullOrEmpty(pair.Section))
        {
            keyPairs.Remove(pair);
        }
    }
    #endregion

    #region gravação do arquivo
    /// <summary>
    /// Salva todas as seções/chaves/valores num arquivo especificado
    /// </summary>
    /// <param name="novoArquivoComPath">Nome completo para o arquivo a ser salvo (se existir será sobreescrito)</param>
    public void Salvar(string novoArquivoComPath)
    {
        StringBuilder strToSave = new StringBuilder();

        List<string> secoes = new List<string>();
        List<string> strChaveValor = new List<string>();

        // primeiro vamos montar um ArrayList com todas as seções diferentes
        foreach (SectionPair sectionPair in keyPairs.Keys)
        {
            if (!secoes.Contains(sectionPair.Section))
                secoes.Add(sectionPair.Section);
        }
        secoes.Sort();

        // para para cada seção:
        foreach (string section in secoes)
        {
            // adiciona no StringBuilder de saida
            strToSave.Append("[" + section + "]\r\n");
            strChaveValor.Clear();

            // vamos percorrer todas as chaves/valor dessa seção
            foreach (SectionPair sectionPair in keyPairs.Keys)
            {
                // é a mesma seção?
                if (sectionPair.Section == section)
                {
                    string tmpValue = (string)keyPairs[sectionPair];

                    if (tmpValue != null)
                        tmpValue = "=" + tmpValue;

                    // adiciona chave/valor
                    strChaveValor.Add(sectionPair.Key + tmpValue);
                }
            }

            // ordena as chaves
            strChaveValor.Sort();

            // percorre cada chave/valor e adiciona na StringBuilder de saída
            foreach (var chaveValor in strChaveValor)
            {
                strToSave.Append(chaveValor);
                strToSave.Append("\r\n");
            }

            // separador de seções
            strToSave.Append("\r\n");
        }

        // vamos remover os últimos \r\n que sobraram para deixar o arquivo limpo
        if (strToSave.Length > 4)
        {
            while (strToSave.ToString(strToSave.Length - 2, 2).Equals("\r\n"))
            {
                strToSave.Remove(strToSave.Length - 2, 2);
            }
        }

        try
        {
            TextWriter tw = new StreamWriter(novoArquivoComPath);
            tw.Write(strToSave.ToString());
            tw.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Salva o arquivo de configuração atual em disco
    /// </summary>
    public void Salvar()
    {
        Salvar(arquivo);
    }
    #endregion

    #region funções para leitura do arquivo de configuração
    /// <summary>
    /// Retorna o valor em formato string. Aceita um valor padrão caso não exista no arquivo
    /// </summary>
    /// <param name="secao">Nome da [seção] onde estará o valor</param>
    /// <param name="chave">Nome da chave (antes do =) onde estará o valor</param>
    /// <param name="padrao">Valor padrão caso não seja encontrado no arquivo</param>
    /// <returns>Retorna a string contendo o valor após o sinal de =</returns>
    public string GetString(string secao, string chave, string padrao = "")
    {
        // busca o pair (secao/chave)
        SectionPair pair = GetSectionPair(secao, chave);

        // se o section estiver vazio não achou, retorna o padrão
        return string.IsNullOrEmpty(pair.Section) ? padrao : (string)keyPairs[pair];
    }

    /// <summary>
    /// Retorna o valor em formato inteiro. Aceita um valor padrão caso não exista no arquivo
    /// </summary>
    /// <param name="secao">Nome da [seção] onde estará o valor</param>
    /// <param name="chave">Nome da chave (antes do =) onde estará o valor</param>
    /// <param name="padrao">Valor padrão caso não seja encontrado no arquivo</param>
    /// <returns>Retorna o inteiro contendo o valor após o sinal de =</returns>
    public int GetInt(string secao, string chave, int padrao = 0)
    {
        string v = GetString(secao, chave, padrao.ToString());
        return ToInt(v, padrao);
    }

    /// <summary>
    /// Retorna o valor em formato bool. Aceita um valor padrão caso não exista no arquivo
    /// </summary>
    /// <param name="secao">Nome da [seção] onde estará o valor</param>
    /// <param name="chave">Nome da chave (antes do =) onde estará o valor</param>
    /// <param name="padrao">Valor padrão caso não seja encontrado no arquivo</param>
    /// <returns>Retorna o bool contendo o valor após o sinal de =</returns>
    /// <remarks>1 = true, qualquer outro valor = false</remarks>
    public bool GetBool(string secao, string chave, bool padrao = false)
    {
        return GetInt(secao, chave, padrao ? 1 : 0) == 1;
    }

    /// <summary>
    /// Retorna o valor em formato decimal. Aceita um valor padrão caso não exista no arquivo
    /// </summary>
    /// <param name="secao">Nome da [seção] onde estará o valor</param>
    /// <param name="chave">Nome da chave (antes do =) onde estará o valor</param>
    /// <param name="padrao">Valor padrão caso não seja encontrado no arquivo</param>
    /// <returns>Retorna decimal contendo o valor após o sinal de =</returns>
    public decimal GetDecimal(string secao, string chave, decimal padrao = 0)
    {
        string v = GetString(secao, chave, padrao.ToString());
        return ToDecimal(v, padrao);
    }

    /// <summary>
    /// Retorna o valor em formato DateTime. Aceita um valor padrão caso não exista no arquivo
    /// </summary>
    /// <param name="secao">Nome da [seção] onde estará o valor</param>
    /// <param name="chave">Nome da chave (antes do =) onde estará o valor</param>
    /// <param name="padrao">Valor padrão caso não seja encontrado no arquivo</param>
    /// <returns>Retorna a DateTime contendo o valor após o sinal de =</returns>
    public DateTime GetDateTime(string secao, string chave, DateTime padrao)
    {
        string v = GetString(secao, chave, padrao.ToString());
        return ToDate(v, padrao);
    }
    #endregion

    #region funções para leitura do arquivo de configuração da seção [Config]
    /// <summary>
    /// Retorna o valor em formato string da seção [Config]. Aceita um valor padrão caso não exista no arquivo.
    /// </summary>
    /// <param name="chave">Nome da chave (antes do =) onde estará o valor</param>
    /// <param name="padrao">Valor padrão caso não seja encontrado no arquivo</param>
    /// <returns>Retorna a string contendo o valor após o sinal de =</returns>
    public string GetStringConfig(string chave, string padrao = "")
    {
        // busca o pair (secao/chave)
        SectionPair pair = GetSectionPair(SECAO_CONFIG, chave);

        // se o section estiver vazio não achou, retorna o padrão
        return string.IsNullOrEmpty(pair.Section) ? padrao : (string)keyPairs[pair];
    }

    /// <summary>
    /// Retorna o valor em formato inteiro da seção [Config]. Aceita um valor padrão caso não exista no arquivo.
    /// </summary>
    /// <param name="chave">Nome da chave (antes do =) onde estará o valor</param>
    /// <param name="padrao">Valor padrão caso não seja encontrado no arquivo</param>
    /// <returns>Retorna a inteiro contendo o valor após o sinal de =</returns>
    public int GetIntConfig(string chave, int padrao = 0)
    {
        string v = GetString(SECAO_CONFIG, chave, padrao.ToString());
        return ToInt(v, padrao);
    }

    /// <summary>
    /// Retorna o valor em formato bool da seção [Config]. Aceita um valor padrão caso não exista no arquivo.
    /// </summary>
    /// <param name="chave">Nome da chave (antes do =) onde estará o valor</param>
    /// <param name="padrao">Valor padrão caso não seja encontrado no arquivo</param>
    /// <returns>Retorna o bool contendo o valor após o sinal de =</returns>
    /// <remarks>1 = true, qualquer outro valor = false</remarks>
    public bool GetBoolConfig(string chave, bool padrao = false)
    {
        return GetInt(SECAO_CONFIG, chave, padrao ? 1 : 0) == 1;
    }

    /// <summary>
    /// Retorna o valor em formato decimal da seção [Config]. Aceita um valor padrão caso não exista no arquivo.
    /// </summary>
    /// <param name="chave">Nome da chave (antes do =) onde estará o valor</param>
    /// <param name="padrao">Valor padrão caso não seja encontrado no arquivo</param>
    /// <returns>Retorna o decimal contendo o valor após o sinal de =</returns>
    public decimal GetDecimalConfig(string chave, decimal padrao = 0)
    {
        string v = GetString(SECAO_CONFIG, chave, padrao.ToString());
        return ToDecimal(v, padrao);
    }

    /// <summary>
    /// Retorna o valor em formato DateTime da seção [Config]. Aceita um valor padrão caso não exista no arquivo.
    /// </summary>
    /// <param name="chave">Nome da chave (antes do =) onde estará o valor</param>
    /// <param name="padrao">Valor padrão caso não seja encontrado no arquivo</param>
    /// <returns>Retorna o DateTime contendo o valor após o sinal de =</returns>
    public DateTime GetDateTimeConfig(string chave, DateTime padrao)
    {
        string v = GetString(SECAO_CONFIG, chave, padrao.ToString());
        return ToDate(v, padrao);
    }
    #endregion

    #region funções para adicionar valores ao arquivo de configuração
    /// <summary>
    /// Adiciona ou altera um valor ao arquivo de configuração. Se a seção não existir será criada. Se a chave não existir será criada.
    /// </summary>
    /// <param name="secao">Nome da [seção] onde estará o valor</param>
    /// <param name="chave">Nome da chave (antes do =) onde estará o valor</param>
    /// <param name="valor">Valor a ser gravado. Aceita vazio</param>
    public void SetString(string secao, string chave, string valor)
    {
        // busca o pair (secao/chave)
        SectionPair pair = GetSectionPair(secao, chave);

        // se não existe, vamos adicionar
        if (string.IsNullOrEmpty(pair.Section))
        {
            pair.Section = secao;
            pair.Key = chave;

            keyPairs.Add(pair, valor);
        }
        else
        {
            // se existe, só troca o valor
            keyPairs[pair] = valor;
        }
    }

    /// <summary>
    /// Adiciona ou altera um valor ao arquivo de configuração. Se a seção não existir será criada. Se a chave não existir será criada.
    /// </summary>
    /// <param name="secao">Nome da [seção] onde estará o valor</param>
    /// <param name="chave">Nome da chave (antes do =) onde estará o valor</param>
    /// <param name="valor">Valor a ser gravado.</param>
    public void SetInt(string secao, string chave, int valor)
    {
        SetString(secao, chave, valor.ToString());
    }

    /// <summary>
    /// Adiciona ou altera um valor ao arquivo de configuração. Se a seção não existir será criada. Se a chave não existir será criada.
    /// </summary>
    /// <param name="secao">Nome da [seção] onde estará o valor</param>
    /// <param name="chave">Nome da chave (antes do =) onde estará o valor</param>
    /// <param name="valor">Valor a ser gravado.</param>
    public void SetBool(string secao, string chave, bool valor)
    {
        SetInt(secao, chave, valor ? 1 : 0);
    }

    /// <summary>
    /// Adiciona ou altera um valor ao arquivo de configuração. Se a seção não existir será criada. Se a chave não existir será criada.
    /// </summary>
    /// <param name="secao">Nome da [seção] onde estará o valor</param>
    /// <param name="chave">Nome da chave (antes do =) onde estará o valor</param>
    /// <param name="valor">Valor a ser gravado.</param>
    public void SetDecimal(string secao, string chave, decimal valor)
    {
        SetString(secao, chave, valor.ToString());
    }

    /// <summary>
    /// Adiciona ou altera um valor ao arquivo de configuração. Se a seção não existir será criada. Se a chave não existir será criada.
    /// </summary>
    /// <param name="secao">Nome da [seção] onde estará o valor</param>
    /// <param name="chave">Nome da chave (antes do =) onde estará o valor</param>
    /// <param name="valor">Valor a ser gravado.</param>
    public void SetDateTime(string secao, string chave, DateTime valor)
    {
        SetString(secao, chave, valor.ToString());
    }

    /// <summary>
    /// Adiciona ou altera um valor ao arquivo de configuração. Se a seção não existir será criada. Se a chave não existir será criada.
    /// </summary>
    /// <param name="secao">Nome da [seção] onde estará o valor</param>
    /// <param name="chave">Nome da chave (antes do =) onde estará o valor</param>
    /// <param name="valor">Valor a ser gravado.</param>
    public void SetDate(string secao, string chave, DateTime valor)
    {
        SetString(secao, chave, valor.ToString("dd/MM/yyyy"));
    }
    #endregion

    #region funções para adicionar valores ao arquivo de configuração da seção [Config]
    /// <summary>
    /// Adiciona ou altera um valor ao arquivo de configuração. A seção será [Config].
    /// </summary>
    /// <param name="chave">Nome da chave (antes do =) onde estará o valor</param>
    /// <param name="valor">Valor a ser gravado.</param>
    public void SetStringConfig(string chave, string valor)
    {
        SetString(SECAO_CONFIG, chave, valor);
    }

    /// <summary>
    /// Adiciona ou altera um valor ao arquivo de configuração. A seção será [Config].
    /// </summary>
    /// <param name="chave">Nome da chave (antes do =) onde estará o valor</param>
    /// <param name="valor">Valor a ser gravado.</param>
    public void SetIntConfig(string chave, int valor)
    {
        SetInt(SECAO_CONFIG, chave, valor);
    }

    /// <summary>
    /// Adiciona ou altera um valor ao arquivo de configuração. A seção será [Config].
    /// </summary>
    /// <param name="chave">Nome da chave (antes do =) onde estará o valor</param>
    /// <param name="valor">Valor a ser gravado.</param>
    public void SetBoolConfig(string chave, bool valor)
    {
        SetIntConfig(chave, valor ? 1 : 0);
    }

    /// <summary>
    /// Adiciona ou altera um valor ao arquivo de configuração. A seção será [Config].
    /// </summary>
    /// <param name="chave">Nome da chave (antes do =) onde estará o valor</param>
    /// <param name="valor">Valor a ser gravado.</param>
    public void SetDecimalConfig(string chave, decimal valor)
    {
        SetDecimal(SECAO_CONFIG, chave, valor);
    }

    /// <summary>
    /// Adiciona ou altera um valor ao arquivo de configuração. A seção será [Config].
    /// </summary>
    /// <param name="chave">Nome da chave (antes do =) onde estará o valor</param>
    /// <param name="valor">Valor a ser gravado.</param>
    public void SetDateTimeConfig(string chave, DateTime valor)
    {
        SetDateTime(SECAO_CONFIG, chave, valor);
    }

    /// <summary>
    /// Adiciona ou altera um valor ao arquivo de configuração. A seção será [Config].
    /// </summary>
    /// <param name="chave">Nome da chave (antes do =) onde estará o valor</param>
    /// <param name="valor">Valor a ser gravado.</param>
    public void SetDateConfig(string chave, DateTime valor)
    {
        SetDate(SECAO_CONFIG, chave, valor);
    }
    #endregion

    #region funções para seções inteiras
    /// <summary>
    /// Retorna uma lista com todas as seções existentes no arquivo 
    /// </summary>
    /// <returns>Lista de strings contendo o nome das seções</returns>
    public List<string> GetSecoes()
    {
        // vamos montar um ArrayList com todas as seções diferentes
        List<string> sections = new List<string>();

        foreach (SectionPair sectionPair in keyPairs.Keys)
        {
            if (!sections.Contains(sectionPair.Section))
                sections.Add(sectionPair.Section);
        }

        return sections;
    }

    /// <summary>
    /// Remove uma seção inteira do arquivo de configuração e suas respectivas chave=valor
    /// </summary>
    /// <param name="secao">Nome da seção a ser removida</param>
    /// <returns>Retorna true caso localizou e removeu</returns>
    public bool ExcluirSecao(string secao)
    {
        bool retorno = false;

        List<SectionPair> listRemover = new List<SectionPair>();

        foreach (SectionPair pair in keyPairs.Keys)
        {
            if (pair.Section.ToUpper().Equals(secao.ToUpper()))
            {
                // eu não posso remover diretamente aqui, porque estamos num looping do próprio
                // neste caso iria abortar o foreach ao remover o primeiro registro
                listRemover.Add(pair);
                retorno = true;
            }
        }

        // vamos remover os que encontrou
        foreach (SectionPair pair in listRemover)
        {
            keyPairs.Remove(pair);
        }

        return retorno;
    }
    #endregion

    /// <summary>
    /// Para utilizar com a chave using. Ele automaticamente salva o arquivo.
    /// </summary>
    public void Dispose()
    {
        this.Salvar();
    }
}