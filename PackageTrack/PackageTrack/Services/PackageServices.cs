using PackageTrack.Models;

namespace PackageTrack.Services;

public class PackageServices
{
    public async Task<Package?> GetByCodeAsync(string code, CancellationToken ct = default)
    {
        await Task.Delay(500, ct); 

        if (string.IsNullOrWhiteSpace(code))
            return null;

        var known = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "BR123", "BR456", "BR789"
        };

        var rnd = new Random(code.GetHashCode());

        if (!known.Contains(code))
        {
            if (code.Length < 5) return null;
        }

        var model = new Package
        {
            Id = code.ToUpperInvariant(),
            Status = rnd.Next(0, 3) switch
            {
                0 => "Postado",
                1 => "Em trânsito",
                _ => "Saiu para entrega"
            },
            ShippedDate = DateTime.Now.Date.AddDays(-rnd.Next(1, 7)),
            EstimatedDelivery = DateTime.Now.Date.AddDays(rnd.Next(1, 5)),
            CurrentLocation = rnd.Next(0, 3) switch
            {
                0 => "Centro de Distribuição - São Paulo/SP",
                1 => "Unidade Operacional - Curitiba/PR",
                _ => "Unidade de Entrega - Belo Horizonte/MG"
            }
        };

        var baseDate = model.ShippedDate;
        model.History.Add(new PackageEvent { Date = baseDate.AddHours(9), Location = "Agência - Origem", Description = "Objeto postado" });
        model.History.Add(new PackageEvent { Date = baseDate.AddDays(1).AddHours(2), Location = "Centro de Distribuição - Origem", Description = "Objeto encaminhado" });
        model.History.Add(new PackageEvent { Date = baseDate.AddDays(2).AddHours(11), Location = "Centro de Distribuição - Intermediário", Description = "Objeto em trânsito" });
        model.History.Add(new PackageEvent { Date = baseDate.AddDays(3).AddHours(8), Location = model.CurrentLocation, Description = "Objeto em processamento" });

        if (model.Status == "Saiu para entrega")
        {
            model.History.Add(new PackageEvent { Date = DateTime.Now.AddHours(-1), Location = model.CurrentLocation, Description = "Saiu para entrega ao destinatário" });
        }

        return model;
    }

    internal async Task GetPackageAsync(string trackingCode)
    {
        throw new NotImplementedException();
    }
}