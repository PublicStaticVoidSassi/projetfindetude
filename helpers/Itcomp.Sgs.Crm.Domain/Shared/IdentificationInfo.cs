using Itcomp.Sgs.Crm.Accounts;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace Itcomp.Shared.Domain;

/// <summary>
/// Représente les informations d'identification d'une entité (entreprise, personne, etc.)
/// Conçu pour être utilisé comme Owned Type dans EF Core.
/// </summary>
public class IdentificationInfo : ValueObject
{
    /// <summary>
    /// Numéro d'Identification Statistique
    /// </summary>
    public string? Nis { get; private set; }

    /// <summary>
    /// Numéro d'Identification Fiscale
    /// </summary>
    public string? Nif { get; private set; }

    /// <summary>
    /// Numéro de Sécurité Sociale
    /// </summary>
    public string? Nss { get; private set; }

    /// <summary>
    /// Relevé d'Identité Bancaire
    /// </summary>
    public string? Rib { get; private set; }

    /// <summary>
    /// Constructeur protégé pour Entity Framework
    /// </summary>
    protected IdentificationInfo()
    {
    }

    /// <summary>
    /// Crée une nouvelle instance de IdentificationInfo
    /// </summary>
    public IdentificationInfo(string? nis, string? nif, string? nss, string? rib)
    {
        SetNis(nis);
        SetNif(nif);
        SetNss(nss);
        SetRib(rib);
    }

    /// <summary>
    /// Définit le NIS avec validation
    /// </summary>
    public IdentificationInfo SetNis(string? nis)
    {
        Check.Length(nis, nameof(nis), AccountConsts.MaxNisLength);
        Nis = nis?.Trim();
        return this;
    }

    /// <summary>
    /// Définit le NIF avec validation
    /// </summary>
    public IdentificationInfo SetNif(string? nif)
    {
        Check.Length(nif, nameof(nif), AccountConsts.MaxNifLength);
        Nif = nif?.Trim();
        return this;
    }

    /// <summary>
    /// Définit le NSS avec validation
    /// </summary>
    public IdentificationInfo SetNss(string? nss)
    {
        Check.Length(nss, nameof(nss), AccountConsts.MaxNssLength);
        Nss = nss?.Trim();
        return this;
    }

    /// <summary>
    /// Définit le RIB avec validation
    /// </summary>
    public IdentificationInfo SetRib(string? rib)
    {
        Check.Length(rib, nameof(rib), AccountConsts.MaxRibLength);
        Rib = rib?.Trim();
        return this;
    }

    /// <summary>
    /// Vérifie si toutes les propriétés sont vides ou nulles
    /// </summary>
    public bool IsEmpty()
    {
        return string.IsNullOrWhiteSpace(Nis) &&
               string.IsNullOrWhiteSpace(Nif) &&
               string.IsNullOrWhiteSpace(Nss) &&
               string.IsNullOrWhiteSpace(Rib);
    }

    /// <summary>
    /// Vérifie si au moins une propriété a une valeur
    /// </summary>
    public bool HasAnyValue()
    {
        return !IsEmpty();
    }

    /// <summary>
    /// Crée une copie de l'instance actuelle
    /// </summary>
    public IdentificationInfo Clone()
    {
        return new IdentificationInfo(Nis, Nif, Nss, Rib);
    }

    /// <summary>
    /// Retourne les composants atomiques pour la comparaison d'égalité (requis par ValueObject)
    /// </summary>
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Nis;
        yield return Nif;
        yield return Nss;
        yield return Rib;
    }
}
