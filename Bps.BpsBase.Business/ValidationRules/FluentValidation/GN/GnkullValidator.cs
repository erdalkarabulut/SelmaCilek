using FluentValidation;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.GN
{
    public class GnkullValidator : AbstractValidator<GNKULL>
    {
        #region ClientService

        #endregion ClientService

        public GnkullValidator()
        {
            RuleFor(p => p.KULKOD).Length(1,20).NotNull();
            RuleFor(p => p.PASSWD).Length(1,200).NotNull();
            RuleFor(p => p.GNNAME).Length(1,50).NotNull();
            RuleFor(p => p.GNSNAM).Length(1,50).NotNull();
            RuleFor(p => p.GNMAIL).MaximumLength(100);
            RuleFor(p => p.GNTELF).MaximumLength(30);
            RuleFor(p => p.LANGKD).Length(1,20).NotNull();
            RuleFor(p => p.PERSID).NotNull();
            RuleFor(p => p.DEFPRO).MaximumLength(20);
            RuleFor(p => p.SCQUKD).Length(1,20).NotNull();
            RuleFor(p => p.SCANSW).Length(1,50).NotNull();
            RuleFor(p => p.ROLEKD).Length(1,20).NotNull();
            RuleFor(p => p.GNTHEM).MaximumLength(50);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
