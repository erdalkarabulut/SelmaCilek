using FluentValidation;
using Bps.BpsBase.Entities.Concrete.IS;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.IS
{
    public class IsrvhrValidator : AbstractValidator<ISRVHR>
    {
        #region ClientService

        #endregion ClientService

        public IsrvhrValidator()
        {
            RuleFor(p => p.GNREZV).Length(1,50).NotNull();
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.VRKODU).MaximumLength(25);
            RuleFor(p => p.URYRKD).Length(1,20).NotNull();
            RuleFor(p => p.DPKODU).Length(1,4).NotNull();
            RuleFor(p => p.OLCUKD).Length(1,20).NotNull();
            RuleFor(p => p.URSPNO).MaximumLength(10);
            RuleFor(p => p.USRSNO).MaximumLength(10);
            RuleFor(p => p.USSTKO).MaximumLength(25);
            RuleFor(p => p.ISLTUR).NotNull();
            RuleFor(p => p.URAKOD).MaximumLength(50);
            RuleFor(p => p.URKLTP).MaximumLength(1);
            RuleFor(p => p.SIRALM).MaximumLength(50);
            RuleFor(p => p.ISPKOD).MaximumLength(20);
            RuleFor(p => p.SIRASI).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
