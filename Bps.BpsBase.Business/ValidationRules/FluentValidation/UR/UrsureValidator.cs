using FluentValidation;
using Bps.BpsBase.Entities.Concrete.UR;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.UR
{
    public class UrsureValidator : AbstractValidator<URSURE>
    {
        #region ClientService

        #endregion ClientService

        public UrsureValidator()
        {
            RuleFor(p => p.ISPKOD).Length(1,20).NotNull();
            RuleFor(p => p.URYRKD).Length(1,20).NotNull();
            RuleFor(p => p.GNREZV).Length(1,50).NotNull();
            RuleFor(p => p.URAKOD).Length(1,50).NotNull();
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.VRKODU).MaximumLength(25);
            RuleFor(p => p.ISYKOD).Length(1,20).NotNull();
            RuleFor(p => p.ISOPKD).Length(1,20).NotNull();
            RuleFor(p => p.ISLTUR).Length(1,20).NotNull();
            RuleFor(p => p.GROLBR).MaximumLength(20);
            RuleFor(p => p.URDRKD).MaximumLength(20);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
